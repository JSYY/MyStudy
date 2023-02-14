using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class Conditions1 : IConditionCheckForWorkflowA
    {
        public void ExcuteCheckForA()
        {
            Console.WriteLine("Conditions1 Check");
        }
    }
}
