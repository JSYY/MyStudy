using OpenClosePrinciple.Example1;
using OpenClosePrinciple.Example2;
using OpenClosePrinciple.Example2.factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenClosePrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            //接口多实现 开闭原则
            //软件对象（类、模块、方法等）应该对于扩展是开放的，对修改是关闭的

            ExcuteExample1();
            ExcuteExample2();
            Console.ReadKey();
        }

        static void ExcuteExample2()
        {
            IMobileFactory samsungFac = new SamsungFactory();
            IMobileFactory appleFac = new AppleFactory();
            IMobileFactory huaweiFac = new HuaweiFactory();

            samsungFac.CreateMobile();
            appleFac.CreateMobile();
            huaweiFac.CreateMobile();
            //如果有新的手机厂商加入，则只需要新增加它的产品（IMobile）和它的工厂(IMobileFactory)即可，不需要改动其他接口和类
        }

        static void ExcuteExample1()
        {
            IWorkflowHandler workflowA = new MethodHandlerImplA();
            IWorkflowHandler workflowB = new MethodHandlerImplB();
            IWorkflowHandler workflowC = new MethodHandlerImplC();

            IList<IWorkflowHandler> list = new List<IWorkflowHandler>();
            list.Add(workflowA);
            list.Add(workflowB);
            list.Add(workflowC);

            InitComponent ic = new InitComponent(list);
            ic.Init();
        }
    }
}
