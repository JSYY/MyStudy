using System;

namespace UIH.MicroConsole.Common.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class InterfaceAspectAttribute : Attribute
    {
        public InterfaceAspectAttribute(Type target)
        {
            Target = target;
        }

        public Type Target { get; private set; }
    }
}
