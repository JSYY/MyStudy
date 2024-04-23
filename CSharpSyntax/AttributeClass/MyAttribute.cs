using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeClass
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class MyAttribute:Attribute
    {
        public string Name { get; set; }
    }


    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class MethodAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
