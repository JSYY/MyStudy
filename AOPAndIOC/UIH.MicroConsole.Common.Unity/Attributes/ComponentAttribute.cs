using System;
using UIH.MicroConsole.Common.Unity.Condition;

namespace UIH.MicroConsole.Common.Unity.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ComponentAttribute : Attribute
    {
        private Type _conditon;

        public ComponentAttribute()
        {
            IsSingleton = true;
        }

        public string Name { get; set; }

        public Type MapFrom { get; set; }

        public bool IsSingleton { get; set; }

        public Type Condition
        {
            get
            {
                return _conditon;
            }
            set
            {
                if (!typeof(IUnityCondition).IsAssignableFrom(value))
                {
                    throw new ArgumentException("Condition must be IUnityCondition type");
                }
                _conditon = value;
            }
        }
    }
}
