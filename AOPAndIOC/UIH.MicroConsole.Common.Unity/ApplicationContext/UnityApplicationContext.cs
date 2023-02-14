using System;
using System.Collections.Generic;
using UIH.MicroConsole.Common.Unity.Condition;
using UIH.MicroConsole.Common.Unity.Dependency;
using UIH.MicroConsole.Common.Unity.Modules;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection;
using Unity.Interception.PolicyInjection.MatchingRules;
using Unity.Lifetime;

namespace UIH.MicroConsole.Common.Unity.ApplicationContext
{
    class UnityApplicationContext : IUnityApplicationContext, IDisposable
    {
        private readonly IUnityContainer _container;
        private readonly IUnityConfiguration _configuration;
        private readonly Interception _interception;
        private List<IUnityModule> _modules;
        private bool disposedValue;

        public UnityApplicationContext()
        {
            _container = new UnityContainer().AddNewExtension<Interception>();
            _container.RegisterInstance<IUnityContainer>(_container);
            _configuration = new UnityConfiguration();
            _container.RegisterInstance<IUnityConfiguration>(_configuration);
            _container.RegisterInstance<IUnityApplicationContext>(this);
            _interception = _container.Configure<Interception>();
        }

        public void Initialize(Type startupModuleType)
        {
            DependencyTree<Type> tree = new DependencyTree<Type>(startupModuleType);
            tree.ResolveFromRootByDependsAttribute();
            List<Type> moduleTypes = tree.SortByDependencyDepth();
            moduleTypes.ForEach(oneModuleType => _container.RegisterType(oneModuleType, TypeLifetime.Singleton));
            _modules = new List<IUnityModule>();
            moduleTypes.ForEach(oneModuleType =>
            {
                _modules.Add(_container.Resolve(oneModuleType) as IUnityModule);
            });
            _modules.ForEach(oneModule =>
            {
                oneModule.PreInitialize();
            });
            RegisterAllAspects();
            RegisterAllComponents();
            _modules.ForEach(oneModule => oneModule.Initialize());
            _modules.ForEach(oneModule => oneModule.PostInitialize());
        }

        private void RegisterAllAspects()
        {
            _configuration.GetAllAspects().ForEach(RegisterAspect);
        }

        private void RegisterAspect(AspectInfo aspect)
        {
            PolicyDefinition policyDefinition = _interception.AddPolicy(aspect.TargetType.FullName)
                .AddMatchingRule<TypeMatchingRule>(new InjectionConstructor(aspect.TargetType.FullName));
            foreach (var callHandler in aspect.HandlerTypes)
            {
                policyDefinition.AddCallHandler(callHandler, new SingletonLifetimeManager());
            }
        }

        private void RegisterAllComponents()
        {
            _configuration.GetAllComponents().ForEach(RegisterComponent);
        }

        private void RegisterComponent(ComponentInfo component)
        {
            if (!NeedRegisterComponent(component))
            {
                return;
            }
            if (_configuration.NeedCreateAspect(component))
            {
                _container.RegisterType(GetRealMapFromType(component), component.MapTo, component.Name,
                    component.IsSingleton ? TypeLifetime.Singleton : TypeLifetime.Transient,
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<PolicyInjectionBehavior>());
            }
            else
            {
                _container.RegisterType(GetRealMapFromType(component), component.MapTo, component.Name, component.IsSingleton ? TypeLifetime.Singleton : TypeLifetime.Transient);
            }
        }

        private bool NeedRegisterComponent(ComponentInfo component)
        {
            if (component.Condition == null)
            {
                return true;
            }
            if (!_container.IsRegistered(component.Condition))
            {
                _container.RegisterType(component.Condition, TypeLifetime.Singleton);
            }
            var condition = _container.Resolve(component.Condition) as IUnityCondition;
            if (condition == null)
            {
                throw new ArgumentException("component's Condition {0} is not an IUnityCondition", "component");
            }
            return condition.IsTrue();
        }

        private Type GetRealMapFromType(ComponentInfo component)
        {
            if (component.MapFrom != null)
            {
                return component.MapFrom;
            }

            // 如果定义了接口，则默认映射到第一个接口
            var interfaces = component.MapTo.GetInterfaces();
            return interfaces.Length >= 1 ? interfaces[0] : component.MapTo;
        }

        public object GetObject(Type type)
        {
            return _container.Resolve(type);
        }

        public object GetObject(Type type, string name)
        {
            return _container.Resolve(type, name);
        }

        public IEnumerable<object> GetAllObjects(Type type)
        {
            return _container.ResolveAll(type);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _container.Dispose();
                    _modules.ForEach(module => module.Shutdown());
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public IUnityContainer GetUnityContainer()
        {
            return _container;
        }

        public void RegisterType(Type type, Type maptoType, string name, bool isSingleton)
        {
            _container.RegisterType(type, maptoType, name, isSingleton ? TypeLifetime.Singleton : TypeLifetime.Transient);
        }

        public void RegisterInstance(Type type, string name, object instance, bool isSingleton)
        {
            _container.RegisterInstance(type, name, instance, isSingleton ? InstanceLifetime.Singleton : InstanceLifetime.PerContainer);
        }

        public bool IsRegistered(Type type, string name)
        {
            return _container.IsRegistered(type, name);
        }
    }
}
