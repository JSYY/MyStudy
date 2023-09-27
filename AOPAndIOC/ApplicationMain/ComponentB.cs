using MyUnity.ApplicationContext;
using MyUnity.Aspects;
using MyUnity.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    public interface IComponentB
    {
        int GetNumber();
    }
    [Component]
    public class ComponentB:IComponentB
    {
        public int GetNumber()
        {
            Console.WriteLine("ComponentB GetNumber");
            return 1;
        }
    }

    [InterfaceAspect(typeof(ComponentB))]
    public class AspectB : BasicInterfaceAspect 
    {

        [AspectMethod(Classification = AspectMethodClassification.After, TargetMethod = "GetNumber")]
        public int AfterGetNumber(AspectContext context)
        {
            Console.WriteLine("AspectB After GetNumber");
            return (int)context.LastHandleResult + 1;
        }

        [AspectMethod(Classification = AspectMethodClassification.Before, TargetMethod = "GetNumber")]
        public int BeforeGetNumber(AspectContext context)
        {
            Console.WriteLine("AspectB Before GetNumber");
            context.IsContinue = true;
            return 0;
        }
    }

}
