using System;
using System.Collections.Generic;
using System.Linq;
using UIH.MicroConsole.Common.Unity.Attributes;
using UIH.MicroConsole.Common.Unity.Modules;

namespace UIH.MicroConsole.Common.Unity.Dependency
{
    public static class DependencyResolver
    {
        public static void ResolveFromRootByDependsAttribute(this DependencyTree<Type> tree)
        {
            var root = tree.Root.Parent;
            if (!IsAnUnityModule(root))
            {
                throw new ArgumentException(string.Format("Root {0} is not an unity module", root.FullName), "tree");
            }

            List<Type> resolvedModuleTypes = new List<Type>();
            FillDependencyTree(tree, root, resolvedModuleTypes);
        }

        private static void FillDependencyTree(DependencyTree<Type> tree, Type moduleType, List<Type> resolvedModuleTypes)
        {
            if (!IsAnUnityModule(moduleType))
            {
                throw new ArgumentException(string.Format("{0} is not an unity module", moduleType.FullName), "moduleType");
            }

            if (resolvedModuleTypes.Contains(moduleType))
            {
                // 已经解析过的类型不再重复解析
                return;
            }

            resolvedModuleTypes.Add(moduleType);
            if (!moduleType.IsDefined(typeof(DependsOnAttribute), true))
            {
                return;
            }

            foreach (var att in moduleType.GetCustomAttributes(typeof(DependsOnAttribute), true).OfType<DependsOnAttribute>())
            {
                foreach (var childModuleType in att.DependedModuleTypes)
                {
                    tree.AddNode(moduleType, childModuleType);
                    FillDependencyTree(tree, childModuleType, resolvedModuleTypes);
                }
            }
        }

        private static bool IsAnUnityModule(Type type)
        {
            return type.IsClass &&
                   !type.IsAbstract &&
                   !type.IsGenericType &&
                   typeof(IUnityModule).IsAssignableFrom(type);
        }
    }
}
