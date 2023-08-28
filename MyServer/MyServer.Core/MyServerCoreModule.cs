using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using MyServer.Configuration;
using MyServer.Localization;
using MyServer.Timing;

namespace MyServer
{

    public class MyServerCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            BEServerProxyLocalizationConfigurer.Configure(Configuration.Localization);
            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyServerCoreModule).GetAssembly());
            IocManager.Register<ServiceReturnToWeb>();
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
            IocManager.Resolve<ServiceReturnToWeb>();
        }
    }
}
