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
            var de = DecoratorObject as DecoratorObject;
            de.PropertyB = "B";
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
