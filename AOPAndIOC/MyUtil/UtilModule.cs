using MyUnity.ApplicationContext;
using MyUnity.Modules;
using System;

namespace MyUtil
{
    public class UtilModule : BasicUnityModule
    {
        private readonly IUnityApplicationContext _applicationContext;

        public UtilModule(IUnityApplicationContext applicationContext, IUnityConfiguration configuration) : base(applicationContext, configuration)
        {
            _applicationContext = applicationContext;
        }
    }
}
