using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyServer.EventToWeb;

namespace MyServer
{
    [DependsOn(
        typeof(MyServerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyServerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyServerApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            IocManager.Register<EventSender>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
            IocManager.Resolve<EventSender>();
        }
    }
}
