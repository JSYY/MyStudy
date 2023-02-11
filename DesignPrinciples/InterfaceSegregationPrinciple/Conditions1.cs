using InterfaceSegregationPrinciple.InterfaceDefine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class Conditions1 : IConditionCheckForWorkflowA,IConditionCheckForWorkflowB
    {
        public void ExcuteCheckForA()
        {
            Check();
        }

        public void Check()
        {
            Console.WriteLine("Conditions1 Check");
        }

        public void ExcuteCheckForB()
        {
            Check();
        }
    }
}
