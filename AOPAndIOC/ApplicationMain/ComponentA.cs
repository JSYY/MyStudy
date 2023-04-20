using ApplicationMain.ConditionsHandler;
using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using UIH.MicroConsole.Common.Unity.ExcuteOrder;

namespace ApplicationMain
{
    public interface IComponentA
    {
        void FunctionA();
    }

    [Component]
    public class ComponentA : IComponentA
    {
        private List<IConditionHandler> _conditionHandlers;
        public ComponentA(List<IConditionHandler> conditionHandlers)
        {
            _conditionHandlers = ExcuteOrderHelper.Sort<IConditionHandler>(conditionHandlers);
        }

        public void FunctionA()
        {
            Console.WriteLine("FunctionA Excute");
            _conditionHandlers.ForEach(item =>
            {
                item.Excute();
            });
        }
    }
}
