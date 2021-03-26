using Dealer.Sourcing.Infrastructure.Repository.Tech;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Dealer.Sourcing.Api.Private.Config.IoC
{
    public static class DependencyResolverExtensions
    {
        public static void RegisterAllRepositories(this IServiceCollection serviceCollection, Assembly assembly)
        {
            assembly.GetTypes().ToList().ForEach(type =>
            {
                if (type.IsClass && type.BaseType != null && IsSubclassOfRawGeneric(typeof(Repository<>), type))
                {
                    var implInterface = type.GetInterfaces().Where(i => !i.IsGenericType).ToList();

                    if (!implInterface.Any())
                        return;

                    implInterface.ForEach(i => serviceCollection.AddScoped(i, type));
                }
            });
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static IServiceCollection RegisterAssemblies(this IServiceCollection serviceCollection, DependencyLifetime lifetime, string[] assemblies, params Type[] markerInterfaces)
        {
            foreach (var asmName in assemblies)
            {
                var asm = Assembly.Load(new AssemblyName(asmName));
                var types = asm.GetTypes()
                    .Where(x =>
                    {
                        var ti = x.GetTypeInfo();
                        var propertiesMatched = ti.IsClass && !ti.IsAbstract && !ti.IsGenericType;
                        var interfacesMatched = ti.ImplementedInterfaces.Select(i => i.Name).Intersect(markerInterfaces.Select(m => m.Name)).Any();

                        return propertiesMatched && interfacesMatched;
                    })
                    .ToList();
                foreach (var type in types)
                {
                    var interfaces = type.GetTypeInfo().ImplementedInterfaces.ToList();
                    foreach (var i in interfaces)
                        Register(serviceCollection, lifetime, i, type);
                }
            }

            return serviceCollection;
        }

        private static void Register(IServiceCollection serviceCollection, DependencyLifetime lifetime, Type interfaceType, Type concreteType)
        {
            switch (lifetime)
            {
                case DependencyLifetime.Transient:
                    serviceCollection.AddTransient(interfaceType, concreteType);
                    break;
                case DependencyLifetime.Scoped:
                    serviceCollection.AddScoped(interfaceType, concreteType);
                    break;
                case DependencyLifetime.Singleton:
                    serviceCollection.AddSingleton(interfaceType, concreteType);
                    break;
            }
        }
    }

    public enum DependencyLifetime
    {
        Transient,
        Singleton,
        Scoped
    }

}
