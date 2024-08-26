using System;

namespace DecoratorPrinciple
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    public abstract class DecoratorHandler
    {
        protected DecoratorHandler Handler { get; set; }
        protected object DecoratorObject { get; set; } 

        public DecoratorHandler(DecoratorHandler decoratorHandler,object decorator)
        {
            Handler = decoratorHandler;
            DecoratorObject = decorator;
        }

        public virtual void Handle()
        {
            Console.WriteLine("的对象{0}",new object[] { DecoratorObject });
        }

    }

    public class DecoratorObject
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string PropertyC { get; set; }
    }
}
