using System;
using System.Collections.Generic;
using System.Linq;

namespace MyUnity.ApplicationContext
{
    public class UnityConfiguration : IUnityConfiguration
    {
        private List<ComponentInfo> _componentList = new List<ComponentInfo>();
        private Dictionary<Type, AspectInfo> _aspects = new Dictionary<Type, AspectInfo>();

        public void AddAspect(AspectInfo aspectInfo)
        {
            if (!_aspects.ContainsKey(aspectInfo.TargetType))
            {
                _aspects[aspectInfo.TargetType] = aspectInfo;
            }
            else
            {
                _aspects[aspectInfo.TargetType].HandlerTypes.AddRange(aspectInfo.HandlerTypes);
            }
        }

        public void AddComponent(ComponentInfo componentInfo)
        {
            _componentList.Add(componentInfo);
        }

        public List<AspectInfo> GetAllAspects()
        {
            return _aspects.Values.ToList();
        }

        public List<ComponentInfo> GetAllComponents()
        {
            return _componentList;
        }

        public bool NeedCreateAspect(ComponentInfo componentInfo)
        {
            return _aspects.ContainsKey(componentInfo.MapTo);
        }
    }
}
