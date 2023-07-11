using MyUnity.ApplicationContext;
using MyUnity.Attributes;
using MyUnity.Modules;
using MyUtil;
using System;

namespace ApplicationMain
{
    public class MainModule: BasicUnityModule
    {
        private readonly IUnityApplicationContext _applicationContext;

        public MainModule(IUnityApplicationContext applicationContext, IUnityConfiguration configuration) : base(applicationContext, configuration)
        {
            _applicationContext = applicationContext;
        }

        public override void PostInitialize()
        {
            _applicationContext.GetObject<IComponentA>().FunctionA();
            Console.WriteLine(_applicationContext.GetObject<IComponentB>().GetNumber());
            var C = _applicationContext.GetObject<IComponentC>();
            _applicationContext.GetObject<IComponentD>().EventHappen();
        }
    }
}
