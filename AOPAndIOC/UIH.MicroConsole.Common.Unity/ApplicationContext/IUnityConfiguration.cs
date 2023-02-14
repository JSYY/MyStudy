using System.Collections.Generic;

namespace UIH.MicroConsole.Common.Unity.ApplicationContext
{
    public interface IUnityConfiguration
    {
        void AddComponent(ComponentInfo componentInfo);
        void AddAspect(AspectInfo aspectInfo);
        List<ComponentInfo> GetAllComponents();
        List<AspectInfo> GetAllAspects();
        bool NeedCreateAspect(ComponentInfo componentInfo);
    }
}
