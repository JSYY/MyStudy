using MyUnity.ApplicationContext;
using MyUnity.Modules;
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
        }
    }
}
