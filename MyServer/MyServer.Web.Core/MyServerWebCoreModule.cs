using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyServer.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyServer
{
    [DependsOn(
         typeof(MyServerApplicationModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class MyServerWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyServerWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyServerConsts.ConnectionStringName
            );
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(MyServerApplicationModule).GetAssembly()
                 );
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyServerWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyServerWebCoreModule).Assembly);
        }
    }
}
