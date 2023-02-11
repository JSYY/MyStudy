using InterfaceSegregationPrinciple.InterfaceDefine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class Conditions2 : IConditionCheckForWorkflowA
    {
        public void ExcuteCheckForA()
        {
            Check();
        }

        public void Check()
        {
            Console.WriteLine("Conditions2 Check");
        }
    }
}
