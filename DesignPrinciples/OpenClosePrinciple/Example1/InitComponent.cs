using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple.Example1
{
    public class InitComponent
    {
        public readonly IList<IWorkflowHandler> _handlers;

        public InitComponent(IList<IWorkflowHandler> handlers)
        {
            _handlers = handlers.ToList();
        }

        public void Init()
        {
            _handlers.ToList().ForEach(item =>
            {
                if(typeof(MethodHandlerImplA) == item.GetType())
                {
                    item.ExcuteMethod();
                }
            });
        }
    }
}
