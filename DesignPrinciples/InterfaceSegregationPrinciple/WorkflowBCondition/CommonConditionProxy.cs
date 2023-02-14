using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple.WorflowACondition
{
    public class CommonConditionProxyForB : IConditionCheckForWorkflowB
    {
        private readonly ICommonCheckCondition _commonCheckCondition;

        public CommonConditionProxyForB(ICommonCheckCondition commonCheckCondition)
        {
            _commonCheckCondition = commonCheckCondition;
        }

        public void ExcuteCheckForB()
        {
            _commonCheckCondition.CommonConditionCheck();
        }
    }
}
