using System.Linq;
using System.Reflection;

namespace UIH.MicroConsole.Common.Unity.Aspects
{
    internal static class MethodHelper
    {
        public static bool IsArgumentsSameWith(this MethodInfo method, MethodInfo target)
        {
            var parameters = method.GetParameters();
            var targetParameters = target.GetParameters();
            return IsParameterInfoSame(parameters, targetParameters);
        }

        public static bool IsSignatureSameWith(this MethodInfo method, MethodInfo target)
        {
            return method.ReturnType == target.ReturnType && method.IsArgumentsSameWith(target);
        }

        public static bool IsAspectBeforeMethodArgumentsMatch(this MethodInfo aspectMethod, MethodInfo target)
        {
            var aspectParameters = aspectMethod.GetParameters();
            var targetParameters = target.GetParameters();
            var lastAspectParameter = aspectParameters.LastOrDefault();
            bool hasAspectContext = lastAspectParameter != null && lastAspectParameter.ParameterType == typeof(AspectContext);
            if (hasAspectContext)
            {
                // 因为这里有可能会拦截原始方法，所以返回类型也要保持和原始方法一致
                return aspectMethod.ReturnType == target.ReturnType && IsParameterInfoSame(aspectParameters.Take(aspectParameters.Length - 1).ToArray(), targetParameters);
            }
            else
            {
                return IsParameterInfoSame(aspectParameters, targetParameters);
            }
        }

        public static bool IsAspectAfterMethodArgumentsMatch(this MethodInfo aspectMethod, MethodInfo target)
        {
            var aspectParameters = aspectMethod.GetParameters();
            var lastAspectParameter = aspectParameters.LastOrDefault();
            if (lastAspectParameter != null && lastAspectParameter.ParameterType == typeof(AspectContext))
            {
                aspectParameters = aspectParameters.Take(aspectParameters.Length - 1).ToArray();
            }

            var targetParameters = target.GetParameters();
            return IsParameterInfoSame(aspectParameters, targetParameters);
        }

        private static bool IsParameterInfoSame(ParameterInfo[] parameters, ParameterInfo[] targetParameters)
        {
            if (parameters.Length != targetParameters.Length)
            {
                return false;
            }
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var targetParameter = targetParameters[i];
                if (parameter.ParameterType != targetParameter.ParameterType
                    || parameter.IsOut != targetParameter.IsOut
                    || parameter.IsOptional != targetParameter.IsOptional)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
