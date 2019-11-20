using Microsoft.Extensions.DependencyInjection;
using SurveyTool.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SurveyTool.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAllImplementationsWithAllInterfaces(this IServiceCollection services, Type interfaceType)
        {
            var assembly = Assembly.GetAssembly(interfaceType);
            var implementingTypes = assembly.GetAllTypesImplementingOpenGenericType(interfaceType);

            foreach (var type in implementingTypes)
            {
                var interfaces = type.GetInterfaces();

                foreach (var intf in interfaces)
                    services.AddTransient(intf, type);
            }
        }
    }
}
