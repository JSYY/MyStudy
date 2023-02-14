using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public interface ICommonCheckCondition
    {
        void CommonConditionCheck();
    }

    public class CommonChcekCondition : ICommonCheckCondition
    {
        public void CommonConditionCheck()
        {
            Console.WriteLine("CommonConditionCheck");
        }
    }
}
