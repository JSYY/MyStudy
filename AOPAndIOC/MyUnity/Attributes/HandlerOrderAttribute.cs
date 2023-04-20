using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIH.MicroConsole.Common.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class HandlerOrderAttribute : Attribute
    {
        public int ExcuteOrder { get; set; }
    }
}
