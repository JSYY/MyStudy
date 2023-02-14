using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class Conditions2 : IConditionCheckForWorkflowB
    {
        public void ExcuteCheckForB()
        {
            Console.WriteLine("Conditions2 Check");
        }

    }
}
