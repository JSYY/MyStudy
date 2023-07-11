using ApplicationMain.ConditionsHandler;
using MyUnity.Attributes;
using MyUtil.Logger;
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
        private IMyLogger _logger;

        public ComponentA(List<IConditionHandler> conditionHandlers,IMyLogger myLogger)
        {
            _conditionHandlers = ExcuteOrderHelper.Sort<IConditionHandler>(conditionHandlers);
            _logger = myLogger;
        }

        public void FunctionA()
        {
            Console.WriteLine("FunctionA Excute");
            _logger.LogDevInformation("asdasdasdasdasdasdasd");
            _conditionHandlers.ForEach(item =>
            {
                item.Excute();
            });
        }
    }
}
