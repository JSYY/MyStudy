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

        public abstract void Handle();

    }
}
