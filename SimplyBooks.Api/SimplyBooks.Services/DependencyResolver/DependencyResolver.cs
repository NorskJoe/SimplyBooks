using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SimplyBooks.Services.DependencyResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterAssemblies(this IServiceCollection serviceCollection, DependancyLifetime lifetime, string[] assemblies, params Type[] markerInterfaces)
        {
            foreach (var asmName in assemblies)
            {
                var asm = Assembly.Load(new AssemblyName(asmName));
                var types = asm.GetTypes()
                    .Where(x => { var ti = x.GetTypeInfo(); return ti.IsClass && !ti.IsAbstract && !ti.IsGenericType && ti.ImplementedInterfaces.Intersect(markerInterfaces).Any(); })
                    .ToList();

                foreach (var type in types)
                {
                    var interfaces = type.GetTypeInfo().ImplementedInterfaces.ToList();
                    var hashset = new HashSet<Type>(interfaces);
                    foreach (var i in interfaces)
                        hashset.ExceptWith(i.GetTypeInfo().ImplementedInterfaces);
                    var intType = hashset.FirstOrDefault();
                    if (intType == null || markerInterfaces.Contains(intType)) continue;

                    Register(serviceCollection, lifetime, intType, type);
                }
            }

            return serviceCollection;
        }

        private static void Register(IServiceCollection serviceCollection, DependancyLifetime lifetime, Type intType, Type concType)
        {
            switch (lifetime)
            {
                case DependancyLifetime.Transient:
                    serviceCollection.AddTransient(intType, concType);
                    break;
                case DependancyLifetime.Scoped:
                    serviceCollection.AddScoped(intType, concType);
                    break;
                case DependancyLifetime.Singleton:
                    serviceCollection.AddSingleton(intType, concType);
                    break;
            }
        }
    }
}
