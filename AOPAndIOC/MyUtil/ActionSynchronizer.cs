using MyUtil.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyUtil
{
    public interface IActionSynchronizer
    {
        void BeginInvoke(Action op);
        void Invoke(Action op);
    }

    public class ActionSynchronizer : ActionSynchronizerBase, IActionSynchronizer
    {
        private readonly Queue<ActionInfo> _actions = new Queue<ActionInfo>();
        private bool _isBusy;

        public ActionSynchronizer(string name) : base(name)
        {
        }

        public void BeginInvoke(Action op)
        {
            ActionInfo actionInfo;
            lock (_syncObj)
            {
                actionInfo = new ActionInfo(++_currentOperationID, op, null);
                _actions.Enqueue(actionInfo);
            }
            _logger.LogDevInformation("{0}Synchronizer begin invoke action {1} {2}", new object[] { _name, actionInfo.ID, actionInfo.Name });
            ExecuteNextActionIfNotBusy();
        }

        protected override void InvokeImpl(Action op)
        {
            using (ManualResetEvent actionEvent = new ManualResetEvent(false))
            {
                ActionInfo actionInfo;
                lock (_syncObj)
                {
                    actionInfo = new ActionInfo(++_currentOperationID, op, actionEvent);
                    _actions.Enqueue(actionInfo);
                }
                _logger.LogDevInformation("{0}Synchronizer invoke action {1} {2}", new object[] { _name, actionInfo.ID, actionInfo.Name });
                var stopwatch = Stopwatch.StartNew();
                ExecuteNextActionIfNotBusy();
                actionEvent.WaitOne();
                _logger.LogDevInformation("{0}Synchronizer invoke action {1} {2} finished cost {3}", new object[] { _name, actionInfo.ID, actionInfo.Name, stopwatch.ElapsedMilliseconds });
            }
        }

        private void ExecuteNextActionIfNotBusy()
        {
            lock (_syncObj)
            {
                if (!_isBusy && _actions.Count > 0)
                {
                    _isBusy = true;
                    ExecuteActionAsync(_actions.Dequeue());
                }
            }
        }

        private void ExecuteActionAsync(ActionInfo actionInfo)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                _currentTID = Thread.CurrentThread.ManagedThreadId;
                ExecuteAction(actionInfo);
                _currentTID = -1;
                OnActionFinished();
            });
        }

        private void OnActionFinished()
        {
            lock (_syncObj)
            {
                if (_actions.Count > 0)
                {
                    ExecuteActionAsync(_actions.Dequeue());
                }
                else
                {
                    _isBusy = false;
                }
            }
        }
    }

    class ActionInfo
    {
        public ActionInfo(long id, Action op, ManualResetEvent executedEvent)
        {
            ID = id;
            Operation = op;
            ExecutedEvent = executedEvent;
            Name = GetActionName(op);
        }

        public long ID { get; private set; }

        public string Name { get; private set; }

        public Action Operation { get; private set; }

        /// <summary>
        /// 操作完成的信号
        /// </summary>
        public ManualResetEvent ExecutedEvent { get; private set; }

        public static string GetActionName(Action op)
        {
            return op.Method.ReflectedType.FullName + "." + op.Method.Name;
        }
    }

    public abstract class ActionSynchronizerBase
    {
        protected readonly MyLogger _logger;
        protected readonly object _syncObj = new object();
        protected long _currentOperationID;
        protected readonly string _name;
        protected volatile int _currentTID = -1;

        protected ActionSynchronizerBase(string name)
        {
            _logger = new MyLogger("MySynchronizer");
            _name = name;
        }
        internal void ExecuteAction(ActionInfo actionInfo)
        {
            _logger.LogDevInformation("{0}Synchronizer start execute action {1} {2}", new object[] { _name, actionInfo.ID, actionInfo.Name });
            var stopwatch = Stopwatch.StartNew();
            actionInfo.Operation();
            if (actionInfo.ExecutedEvent != null)
            {
                actionInfo.ExecutedEvent.Set();
            }
            _logger.LogDevInformation("{0}Synchronizer finish execute action {1} {2} cost {3}", new object[] { _name, actionInfo.ID, actionInfo.Name, stopwatch.ElapsedMilliseconds });
        }

        public void Invoke(Action op)
        {
            if (_currentTID == Thread.CurrentThread.ManagedThreadId)
            {
                // 同一个任务队列直接执行操作
                string actionName = ActionInfo.GetActionName(op);
                _logger.LogDevInformation("{0}Synchronizer invoke action {1} directly", new object[] { _name, actionName });
                op();
                _logger.LogDevInformation("{0}Synchronizer invoke action {1} finished", new object[] { _name, actionName });
            }
            else
            {
                InvokeImpl(op);
            }
        }

        protected abstract void InvokeImpl(Action op);
    }
}
