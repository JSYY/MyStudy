using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPrinciple
{
    public class ComponentBDecorator : DecoratorHandler
    {
        public ComponentBDecorator(DecoratorHandler decoratorHandler, object obj) : base(decoratorHandler, obj)
        {

        }

        public override void Handle()
        {
            Console.WriteLine("ComponentBDecorator start handle");
            if (Handler != null)
            {
                Handler.Handle();
            }
        }
    }
}
