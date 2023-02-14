using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UIH.MicroConsole.Common.Unity.ApplicationContext;
using UIH.MicroConsole.Common.Unity.Attributes;

namespace UIH.MicroConsole.Common.Unity.Modules
{
    public abstract class BasicUnityModule : UnityModule
    {
        private readonly IUnityApplicationContext _applicationContext;
        private readonly IUnityConfiguration _configuration;
        private readonly List<ComponentInfo> _addedComponents;

        protected BasicUnityModule(IUnityApplicationContext applicationContext, IUnityConfiguration configuration)
        {
            _applicationContext = applicationContext;
            _configuration = configuration;
            _addedComponents = new List<ComponentInfo>();
        }

        public override void PreInitialize()
        {
            GetType().Assembly.GetTypes().ToList().ForEach(PreprocessType);
        }

        private void PreprocessType(Type t)
        {
            if (t.IsClass && !t.IsAbstract && !t.IsValueType && t.IsVisible)
            {
                if (t.IsDefined(typeof(ComponentAttribute), false))
                {
                    PreProcessComponentType(t);
                }
                else if (t.IsDefined(typeof(InterfaceAspectAttribute), false))
                {
                    PreProcessAspectType(t);
                }
            }
        }

        protected virtual void PreProcessComponentType(Type t)
        {
            ComponentAttribute attribute = (ComponentAttribute)t.GetCustomAttributes(typeof(ComponentAttribute), false)[0];
            var component = new ComponentInfo
            {
                Name = attribute.Name,
                MapFrom = attribute.MapFrom,
                MapTo = t,
                IsSingleton = attribute.IsSingleton,
                Condition = attribute.Condition,
            };
            if (component.MapFrom == null)
            {
                // 如果定义了接口，则默认映射到第一个接口
                var interfaces = t.GetInterfaces();
                component.MapFrom = interfaces.Length >= 1 ? interfaces[0] : t;
            }
            _configuration.AddComponent(component);
            _addedComponents.Add(component);
        }

        protected virtual void PreProcessAspectType(Type t)
        {
            InterfaceAspectAttribute attribute = (InterfaceAspectAttribute)t.GetCustomAttributes(typeof(InterfaceAspectAttribute), false)[0];
            _configuration.AddAspect(new AspectInfo
            {
                TargetType = attribute.Target,
                HandlerTypes = new List<Type> { t },
            });
        }

        protected virtual void PreProcessOtherType(Type t)
        {
        }

        public override void PostInitialize()
        {
            _addedComponents.ForEach(component =>
            {
                foreach (var methodInfo in component.MapTo.GetMethods())
                {
                    if (methodInfo.IsDefined(typeof(ComponentSetterAttribute), true))
                    {
                        var parameters = methodInfo.GetParameters();
                        object[] args = new object[parameters.Length];
                        for (int i = 0; i < args.Length; i++)
                        {
                            args[parameters[i].Position] = _applicationContext.GetObject(parameters[i].ParameterType);
                        }
                        if (_configuration.NeedCreateAspect(component))
                        {
                            var interceptProxy = _applicationContext.GetObject(component.MapFrom);
                            methodInfo.Invoke(interceptProxy.GetType().GetField("target", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(interceptProxy), args);
                        }
                        else
                        {
                            methodInfo.Invoke(_applicationContext.GetObject(component.MapFrom), args);
                        }
                    }
                }
            });
        }

        public override void Shutdown()
        {
            // 释放资源
        }
    }
}
