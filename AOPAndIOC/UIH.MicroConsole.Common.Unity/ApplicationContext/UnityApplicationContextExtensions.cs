using System.Collections.Generic;
using System.Linq;

namespace UIH.MicroConsole.Common.Unity.ApplicationContext
{
    public static class UnityApplicationContextExtensions
    {
        public static T GetObject<T>(this IUnityApplicationContext context)
        {
            return (T)context.GetObject(typeof(T));
        }

        public static T GetObject<T>(this IUnityApplicationContext context, string name)
        {
            return (T)context.GetObject(typeof(T), name);
        }

        public static IEnumerable<T> GetAllObjects<T>(this IUnityApplicationContext context)
        {
            return context.GetAllObjects(typeof(T)).Cast<T>();
        }

        public static void RegisterType<TMapFrom, TMapTo>(this IUnityApplicationContext context)
        {
            context.RegisterType(typeof(TMapFrom), typeof(TMapTo), null, true);
        }

        public static void RegisterType<TMapFrom, TMapTo>(this IUnityApplicationContext context, bool isSingleton)
        {
            context.RegisterType(typeof(TMapFrom), typeof(TMapTo), null, isSingleton);
        }

        public static void RegisterType<TMapFrom, TMapTo>(this IUnityApplicationContext context, string name, bool isSingleton)
        {
            context.RegisterType(typeof(TMapFrom), typeof(TMapTo), name, isSingleton);
        }

        public static void RegisterInstance<T>(this IUnityApplicationContext context, object instance)
        {
            context.RegisterInstance(typeof(T), null, instance, true);
        }

        public static void RegisterInstance<T>(this IUnityApplicationContext context, object instance, bool isSingleton)
        {
            context.RegisterInstance(typeof(T), null, instance, isSingleton);
        }

        public static void RegisterInstance<T>(this IUnityApplicationContext context, string name, object instance, bool isSingleton)
        {
            context.RegisterInstance(typeof(T), name, instance, isSingleton);
        }

        public static bool IsRegistered<T>(this IUnityApplicationContext context)
        {
            return context.IsRegistered(typeof(T), null);
        }

        public static bool IsRegistered<T>(this IUnityApplicationContext context, string name)
        {
            return context.IsRegistered(typeof(T), name);
        }
    }
}
