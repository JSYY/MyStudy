using ApplicationMain.ConditionsHandler;
using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _conditionHandlers = Sort(conditionHandlers);

        }

        private List<IConditionHandler> Sort(List<IConditionHandler> conditionHandlers)
        {
            conditionHandlers.Sort((x,y)=>x.GetExcuteOrder().CompareTo(y.GetExcuteOrder()));
            return conditionHandlers;
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
