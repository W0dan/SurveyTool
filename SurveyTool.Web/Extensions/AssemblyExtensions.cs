using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SurveyTool.Web.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(this Assembly assembly, Type openGenericType)
        {
            return from x in assembly.GetTypes()
                   from z in x.GetInterfaces()
                   let y = x.BaseType
                   where
                   y != null && y.IsGenericType &&
                   openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition()) ||
                   z.IsGenericType &&
                   openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition())
                   select x;
        }
    }
}
