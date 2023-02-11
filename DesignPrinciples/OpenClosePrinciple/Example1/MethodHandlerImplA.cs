using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple
{
    public class MethodHandlerImplA : IWorkflowHandler
    {
        public void ExcuteMethod()
        {
            Console.WriteLine("MethodHandlerImplA excute");
        }
    }
}
