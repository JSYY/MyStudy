using System.Collections.Generic;

namespace MyUnity.ApplicationContext
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
