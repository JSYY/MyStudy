using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIH.MicroConsole.Common.Unity.Attributes;

namespace UIH.MicroConsole.Common.Unity.ExcuteOrder
{
    public static class ExcuteOrderHelper
    {
        public static List<T> Sort<T>(List<T> conditionHandlers)
        {
            conditionHandlers.Sort((x, y) => {
                return ((HandlerOrderAttribute)x.GetType().GetCustomAttributes(typeof(HandlerOrderAttribute), false).FirstOrDefault()).ExcuteOrder.
                CompareTo(((HandlerOrderAttribute)y.GetType().GetCustomAttributes(typeof(HandlerOrderAttribute), false).FirstOrDefault()).ExcuteOrder);
            });
            return conditionHandlers;
        }
    }
}
