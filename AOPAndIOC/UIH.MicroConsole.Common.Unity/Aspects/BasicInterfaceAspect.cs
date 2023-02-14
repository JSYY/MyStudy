using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UIH.MicroConsole.Common.Unity.ApplicationContext;
using UIH.MicroConsole.Common.Unity.Attributes;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UIH.MicroConsole.Common.Unity.Aspects
{
    public abstract class BasicInterfaceAspect : ICallHandler
    {
        private readonly Dictionary<AspectMethodClassification, Dictionary<string, List<MethodInfo>>> _aspectMethodMap;
        public int Order
        {
            get;
            set;
        }

        protected BasicInterfaceAspect()
        {
            _aspectMethodMap = new Dictionary<AspectMethodClassification, Dictionary<string, List<MethodInfo>>>();
            foreach (var enumValue in Enum.GetValues(typeof(AspectMethodClassification)).OfType<AspectMethodClassification>())
            {
                _aspectMethodMap.Add(enumValue, new Dictionary<string, List<MethodInfo>>());
            }
            InitializeAspectMethodsByAttribute();
        }

        private void InitializeAspectMethodsByAttribute()
        {
            foreach (var method in GetType().GetMethods())
            {
                if (method.IsAbstract || method.IsVirtual || method.IsStatic
                    || !method.IsDefined(typeof(AspectMethodAttribute)))
                {
                    continue;
                }
                var attribute = method.GetCustomAttribute<AspectMethodAttribute>(false);
                AddNewAspectMethod(method, attribute);
            }
        }

        private void AddNewAspectMethod(MethodInfo method, AspectMethodAttribute attribute)
        {
            var map = _aspectMethodMap[attribute.Classification];
            if (!map.ContainsKey(attribute.TargetMethod))
            {
                map[attribute.TargetMethod] = new List<MethodInfo> { method };
            }
            else
            {
                map[attribute.TargetMethod].Add(method);
            }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (input.MethodBase is not MethodInfo)
            {
                return getNext().Invoke(input, getNext);
            }

            MethodInfo inputMethod = (MethodInfo)input.MethodBase;
            var beforeMethod = GetMatchedAspectMethod(inputMethod, AspectMethodClassification.Before);
            if (beforeMethod != null)
            {
                var context = new AspectContext();
                var beforeResult = InvokeAspectMethod(input, beforeMethod, context);
                if (!context.IsContinue)
                {
                    return beforeResult;
                }
            }

            var result = getNext().Invoke(input, getNext);
            if (result.Exception != null)
            {
                var exceptionMethod = GetMatchedAspectMethod(inputMethod, AspectMethodClassification.Exception);
                if (exceptionMethod != null)
                {
                    InvokeAspectMethod(input, exceptionMethod, null);
                }
                return result;
            }
            else
            {
                var afterMethod = GetMatchedAspectMethod(inputMethod, AspectMethodClassification.After);
                if (afterMethod != null)
                {
                    AspectContext context = new AspectContext { LastHandleResult = result.ReturnValue };
                    var afterResult = InvokeAspectMethod(input, afterMethod, context);
                    return afterMethod.ReturnType == typeof(void) ? result : afterResult;
                }
                else
                {
                    return result;
                }
            }
        }

        private MethodInfo GetMatchedAspectMethod(MethodInfo inputMethod, AspectMethodClassification classification)
        {
            if (!_aspectMethodMap[classification].ContainsKey(inputMethod.Name))
            {
                return null;
            }

            var aspectMethodList = _aspectMethodMap[classification][inputMethod.Name];
            return aspectMethodList.FirstOrDefault(aspectMethod =>
            {
                switch (classification)
                {
                    case AspectMethodClassification.Before:
                        return aspectMethod.IsAspectBeforeMethodArgumentsMatch(inputMethod);
                    case AspectMethodClassification.After:
                        return aspectMethod.IsAspectAfterMethodArgumentsMatch(inputMethod);
                    case AspectMethodClassification.Exception:
                        return aspectMethod.IsArgumentsSameWith(inputMethod);
                    default:
                        return false;
                }
            });
        }

        private IMethodReturn InvokeAspectMethod(IMethodInvocation input, MethodInfo aspectMethod, AspectContext context)
        {
            var aspectMethodArgsLength = aspectMethod.GetParameters().Length;
            object[] arguments = new object[aspectMethodArgsLength];
            List<int> outputIndexList = new List<int>();
            for (int i = 0; i < input.Arguments.Count; i++)
            {
                var parameterInfo = input.Arguments.GetParameterInfo(i);
                arguments[i] = input.Arguments[parameterInfo.Name];
                if (parameterInfo.IsOut || parameterInfo.ParameterType.IsByRef)
                {
                    outputIndexList.Add(i);
                }
            }
            if (input.Arguments.Count + 1 == aspectMethodArgsLength)
            {
                arguments[aspectMethodArgsLength - 1] = context;
            }
            object returnValue = aspectMethod.Invoke(this, arguments);
            object[] outputValues = new object[outputIndexList.Count];
            for (int i = 0; i < outputValues.Length; i++)
            {
                outputValues[i] = arguments[outputIndexList[i]];
            }
            return input.CreateMethodReturn(returnValue, outputValues);
        }
    }
}
