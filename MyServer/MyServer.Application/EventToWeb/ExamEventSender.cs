using Abp;
using MyServer.Hubs;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MyServer.EventToWeb
{
    public class EventSender : IDisposable
    {
        private Timer _timer;
        protected readonly WebConsoleHub _hub;
        private readonly ServiceReturnToWeb _serviceReturn;

        public EventSender(WebConsoleHub hub,ServiceReturnToWeb serviceReturn)
        {
            _hub = hub;
            _serviceReturn = serviceReturn;
            _serviceReturn.OnDataChanged += TestHandler;
        }

        private void TestHandler(object sender, MyEventArgs e)
        {
            _ = _hub.SendMessage("TestMessage", e.name);
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
