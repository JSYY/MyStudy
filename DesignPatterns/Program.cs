using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 观察者模式
            EventMaker eventMaker = new EventMaker();
            RealObserver r1 = new RealObserver("zhangsan");
            RealObserver r2 = new RealObserver("lisi");
            eventMaker.Attach(r1);
            eventMaker.Attach(r2);
            eventMaker.SetAction("work");

            eventMaker.Detach(r2);
            eventMaker.SetAction("rest");
            #endregion

            #region 工厂模式
            IFactory carFactory= new CarFactory();
            IFactory phoneFactory = new PhoneFactory();
            carFactory.CreateProduct();
            phoneFactory.CreateProduct();
            #endregion

            Console.ReadKey();
        }
    }
}
