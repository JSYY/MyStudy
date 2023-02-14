using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple.WorflowACondition
{
    public class CommonConditionProxyForA : IConditionCheckForWorkflowA
    {
        private readonly ICommonCheckCondition _commonCheckCondition;

        public CommonConditionProxyForA(ICommonCheckCondition commonCheckCondition)
        {
            _commonCheckCondition = commonCheckCondition;
        }

        public void ExcuteCheckForA()
        {
            _commonCheckCondition.CommonConditionCheck();
        }
    }
}
