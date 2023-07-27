using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyServer.Configuration;

namespace MyServer.Web.Host.Startup
{
    [DependsOn(
       typeof(MyServerWebCoreModule))]
    public class MyServerWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyServerWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyServerWebHostModule).GetAssembly());
        }
    }
}
