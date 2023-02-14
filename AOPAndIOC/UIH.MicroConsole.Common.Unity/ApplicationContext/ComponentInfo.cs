using System;

namespace UIH.MicroConsole.Common.Unity.ApplicationContext
{
    public class ComponentInfo
    {
        public string Name { get; set; }

        public Type MapFrom { get; set; }

        public Type MapTo { get; set; }

        public Type Condition { get; set; }

        public bool IsSingleton { get; set; }
    }
}
