using System;
using System.Collections.Generic;

namespace MyUnity.ApplicationContext
{
    public class AspectInfo
    {
        public Type TargetType { get; set; }

        public List<Type> HandlerTypes { get; set; }
    }
}
