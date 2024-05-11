using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPrinciple
{
    public class ComponentCDecorator : DecoratorHandler
    {
        public ComponentCDecorator(DecoratorHandler decoratorHandler,object obj) : base(decoratorHandler,obj)
        {

        }

        public override void Handle()
        {
            Console.WriteLine("ComponentCDecorator start handle");
            if (Handler != null)
            {
                Handler.Handle();
            }
        }
    }
}
