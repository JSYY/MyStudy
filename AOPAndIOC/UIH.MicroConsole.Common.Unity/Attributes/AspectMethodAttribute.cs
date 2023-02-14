using System;
using UIH.MicroConsole.Common.Unity.ApplicationContext;

namespace UIH.MicroConsole.Common.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class AspectMethodAttribute : Attribute
    {
        public string TargetMethod { get; set; }

        public AspectMethodClassification Classification { get; set; }
    }
}
