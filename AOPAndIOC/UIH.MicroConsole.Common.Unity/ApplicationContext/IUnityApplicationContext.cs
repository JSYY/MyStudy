using System;
using System.Collections.Generic;

namespace MyUnity.ApplicationContext
{
    public interface IUnityApplicationContext
    {
        object GetObject(Type type);
        object GetObject(Type type, string name);
        IEnumerable<object> GetAllObjects(Type type);
        void RegisterType(Type type, Type maptoType, string name, bool isSingleton);
        void RegisterInstance(Type type, string name, object instance, bool isSingleton);
        bool IsRegistered(Type type, string name);
    }
}
