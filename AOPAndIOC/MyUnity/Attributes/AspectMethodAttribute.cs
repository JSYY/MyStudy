using System;
using MyUnity.ApplicationContext;

namespace MyUnity.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class AspectMethodAttribute : Attribute
    {
        public string TargetMethod { get; set; }

        public AspectMethodClassification Classification { get; set; }
    }
}
