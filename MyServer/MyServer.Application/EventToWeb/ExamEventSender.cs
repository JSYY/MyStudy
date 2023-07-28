using Abp;
using MyServer.Hubs;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyServer.EventToWeb
{
    public class ExamEventSender : EventSenderBase, IShouldInitialize,IDisposable
    {
        private Timer _timer; 

        public ExamEventSender(WebConsoleHub hub)
            : base(hub)
        {
            _timer = new Timer(state => TestHandler());
            _timer.Change(0, 2000);
        }

        public void Initialize()
        {
            TryRegisterEventImpl();
        }
       
        protected override void TryRegisterEventImpl()
        {
            base.TryRegisterEventImpl();
        }

        private void TestHandler()
        {
            _ = _hub.SendMessage("TestMessage", string.Empty);
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
