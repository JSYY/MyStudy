using InterfaceSegregationPrinciple.WorflowACondition;
using System;
using System.Collections.Generic;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            //接口应该尽量细化，一个接口对应一个功能模块，同时接口里面的方法应该尽可能的少，使接口更加灵活轻便。
            //或许有的人认为接口隔离原则和单一职责原则很像，但两个原则还是存在着明显的区别。单一职责原则是在业务逻辑上的划分，注重的是职责。
            //接口隔离原则是基于接口设计考虑。例如一个接口的职责包含10个方法，这10个方法都放在同一接口中，并且提供给多个模块调用，
            //但不同模块需要依赖的方法是不一样的，这时模块为了实现自己的功能就不得不实现一些对其没有意义的方法，这样的设计是不符合接口隔离原则的。
            //接口隔离原则要求"尽量使用多个专门的接口"专门提供给不同的模块。

            
            Conditions1 conditions1 = new Conditions1();
            Conditions2 conditions2 = new Conditions2();
            ICommonCheckCondition commonCheckCondition = new CommonChcekCondition();
            CommonConditionProxyForA commonConditionProxyForA = new CommonConditionProxyForA(commonCheckCondition);
            CommonConditionProxyForB commonConditionProxyForB = new CommonConditionProxyForB(commonCheckCondition);

            List<IConditionCheckForWorkflowA> list1 = new List<IConditionCheckForWorkflowA>();
            list1.Add(conditions1);
            list1.Add(commonConditionProxyForA);

            List<IConditionCheckForWorkflowB> list2 = new List<IConditionCheckForWorkflowB>();
            list2.Add(conditions2);
            list2.Add(commonConditionProxyForB);

            WorkflowA workflowA = new WorkflowA(list1);
            WorkflowB workflowB = new WorkflowB(list2);

            workflowA.DoSomething();
            workflowB.DoSomething();


        }
    }
}
