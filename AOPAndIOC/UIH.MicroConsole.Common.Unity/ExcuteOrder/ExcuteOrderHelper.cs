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
                var a = (HandlerOrderAttribute)x.GetType().GetCustomAttributes(typeof(HandlerOrderAttribute), false).FirstOrDefault();
                var b = (HandlerOrderAttribute)y.GetType().GetCustomAttributes(typeof(HandlerOrderAttribute), false).FirstOrDefault();
                return a.ExcuteOrder.CompareTo(b.ExcuteOrder);
            });
            return conditionHandlers;
        }
    }
}
