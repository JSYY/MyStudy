using Abp;
using MyServer.Hubs;
using Google.Protobuf;
using System;
using System.Collections.Generic;

namespace MyServer.EventToWeb
{
    public class ExamEventSender : EventSenderBase, IShouldInitialize
    {

        public ExamEventSender(WebConsoleHub hub)
            : base(hub)
        {
           

        }
        public void Initialize()
        {
            TryRegisterEventImpl();
        }
       
        protected override void TryRegisterEventImpl()
        {
            base.TryRegisterEventImpl();


        }

    }

}
