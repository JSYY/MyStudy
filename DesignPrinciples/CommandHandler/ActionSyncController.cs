using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandler
{
    public class ActionInfo
    {
        public int actionID { get; set; }
        public Action action { get; set; }
        public string actionName { get; set; }
    }

    /// <summary>
    /// 保证队列按顺序执行
    /// </summary>
    public interface IActionSyncController
    {
        void AddAction(Action action,string name);
    }

    public class ActionSyncController:IActionSyncController
    {
        private readonly Queue<ActionInfo> _actions = new Queue<ActionInfo>();
        private bool _isBusy;
        private readonly object _syncObj = new object();

        public ActionSyncController()
        {
            
        }

        public void AddAction(Action action,string name)
        {
            var ac = new ActionInfo();
            ac.action = action;
            ac.actionName = name;
            _actions.Enqueue(ac);
            ExcuteActionIfNotBusy();
        }

        private void ExcuteActionIfNotBusy()
        {
            if (_actions.Count > 0 && !_isBusy)
            {
                _isBusy = true;
                ExcuteActionAsync(_actions.Dequeue());
            }
        }

        private void ExcuteActionAsync(ActionInfo actionInfo)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                ExcuteAction(actionInfo);
                OnActionFinished();
            });
        }

        private void ExcuteAction(ActionInfo actionInfo)
        {
            //执行任务
            var stopwatch = Stopwatch.StartNew();
            actionInfo.actionID = Thread.GetCurrentProcessorId();
            actionInfo.action();
            Console.WriteLine("processid{0} excute action {1} cost {2} ",new object[] { actionInfo.actionID,actionInfo.actionName,stopwatch.ElapsedMilliseconds });
        }

        private void OnActionFinished()
        {
            lock (_syncObj)
            {
                if (_actions.Count > 0)
                {
                    ExcuteActionAsync(_actions.Dequeue());
                }
                else
                {
                    _isBusy = false;
                }
            }
        }
    }
}
