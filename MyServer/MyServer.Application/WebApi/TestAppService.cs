using Abp.Web.Models;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using MyServer;
using System;
using System.Threading.Tasks;

namespace BEServerProxy.WebApi.MainFrame
{
    public class TestAppService : MyServerAppServiceBase
    {
        private readonly ServiceReturnToWeb _serviceReturn;

        public TestAppService(ServiceReturnToWeb serviceReturn)
        {
            _serviceReturn = serviceReturn;
        }

        [HttpGet]
        [DontWrapResult]
        public void TestMethod()
        {
            //前端Api  api/services/app/Test/TestMethod
            Console.WriteLine("Test");
            _serviceReturn.notifyData();
        }
    }
}
