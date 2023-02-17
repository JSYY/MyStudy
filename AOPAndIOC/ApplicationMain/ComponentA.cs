using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    public interface IComponentA
    {
        void FunctionA();
    }

    [Component]
    public class ComponentA : IComponentA
    {
        public ComponentA()
        {
        }

        public void FunctionA()
        {
            Console.WriteLine("FunctionA Excute");
        }
    }
}
