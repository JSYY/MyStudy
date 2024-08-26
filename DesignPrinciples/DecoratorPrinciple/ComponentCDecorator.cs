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
            var de = DecoratorObject as DecoratorObject;
            de.PropertyC = "C";
            if (Handler != null)
            {
                Handler.Handle();
            }
            else
            {
                base.Handle();
            }
        }
    }
}
