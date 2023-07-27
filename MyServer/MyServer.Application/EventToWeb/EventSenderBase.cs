using System;
using System.Threading;
using MyServer.Hubs;

namespace MyServer.EventToWeb
{
    public interface IEventSender
    {
        void TryRegisterEvent();
    }
    public abstract class EventSenderBase : IEventSender
    {
        protected readonly WebConsoleHub _hub;

        protected EventSenderBase(WebConsoleHub hub)
        {
            _hub = hub;
        }
        public void TryRegisterEvent()
        {
            TryRegisterEventImpl();
        }

        protected virtual void TryRegisterEventImpl()
        {
        }
    }
}
