using InterfaceSegregationPrinciple.InterfaceDefine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class WorkflowA
    {
        private readonly List<IConditionCheckForWorkflowA> _conditions;
        public WorkflowA(List<IConditionCheckForWorkflowA> conditionCheckFors)
        {
            _conditions = conditionCheckFors.ToList();
        }

        public void DoSomething()
        {
            Console.WriteLine("WorkflowA DoSomething");
            _conditions.ForEach(item =>
            {
                item.ExcuteCheckForA();
            });
        }
    }


    public class WorkflowB
    {
        private readonly List<IConditionCheckForWorkflowB> _conditions;
        public WorkflowB(List<IConditionCheckForWorkflowB> conditionCheckFors)
        {
            _conditions = conditionCheckFors.ToList();
        }

        public void DoSomething()
        {
            Console.WriteLine("WorkflowB DoSomething");
            _conditions.ForEach(item =>
            {
                item.ExcuteCheckForB();
            });
        }
    }
}
