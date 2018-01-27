using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConventionMapper
{
    internal static class Reflect
    {
        public static T New<T>() where T : new() => Activator.CreateInstance<T>();

        public static T New<T>(params object[] parameters) => New<T>(typeof(T), parameters);

        public static T New<T>(this Type type, params object[] parameters) => (T)Activator.CreateInstance(type, parameters);

        public static MethodInfo GetGenMethod(this Type type, string methodName, params Type[] parametersTypes)
            => type.GetMethod(methodName).MakeGenericMethod(parametersTypes);

        public static MethodInfo GetGenTypeMethod(this Type type, string methodName, params Type[] parametersTypes)
            => type.MakeGenericType(parametersTypes).GetMethod(methodName);
    }
}
