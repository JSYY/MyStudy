using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain.ConditionsHandler
{
    [Component(Name = "ConditionA")]
    public class ConditionA : IConditionHandler
    {
        public readonly int order = 2;

        public void Excute()
        {
            Console.WriteLine("ConditionsA excute!!!");
        }

        public int GetExcuteOrder()
        {
            return order;
        }
    }
    
    [Component(Name = "ConditionB")]
    public class ConditionB : IConditionHandler
    {
        public readonly int order = 1;
        public void Excute()
        {
            Console.WriteLine("ConditionsB excute!!!");
        }

        public int GetExcuteOrder()
        {
            return order;
        }
    }

    [Component(Name = "ConditionC")]
    public class ConditionC : IConditionHandler
    {
        public readonly int order = 3;

        public void Excute()
        {
            Console.WriteLine("ConditionsC excute!!!");
        }

        public int GetExcuteOrder()
        {
            return order;
        }
    }
}
