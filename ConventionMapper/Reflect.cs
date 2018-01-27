using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConventionMapper
{
    internal static class Reflect
    {
        public static T New<T>(this Type type, params object[] parameters) => (T)Activator.CreateInstance(type, parameters);
    }
}
