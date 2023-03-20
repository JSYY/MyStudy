using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIH.MicroConsole.Common.Unity.Attributes;

namespace ApplicationMain.ConditionsHandler
{
    [HandlerOrder(ExcuteOrder = 3)]
    [Component(Name = "ConditionA")]
    public class ConditionA : IConditionHandler
    {

        public void Excute()
        {
            Console.WriteLine("ConditionsA excute!!!");
        }

    }

    [HandlerOrder(ExcuteOrder = 1)]
    [Component(Name = "ConditionB")]
    public class ConditionB : IConditionHandler
    {
        public void Excute()
        {
            Console.WriteLine("ConditionsB excute!!!");
        }

    }

    [HandlerOrder(ExcuteOrder = 2)]
    [Component(Name = "ConditionC")]
    public class ConditionC : IConditionHandler
    {

        public void Excute()
        {
            Console.WriteLine("ConditionsC excute!!!");
        }

    }
}
