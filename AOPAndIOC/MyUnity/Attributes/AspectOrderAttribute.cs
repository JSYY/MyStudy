using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnity.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AspectOrderAttribute:Attribute
    {
        public Type AheadTargetInterface { get; set; }
        public Type BehindTargetInterface { get; set; }
    }
}
