using Microsoft.Extensions.DependencyInjection;
using Shapes.AreaCalculator.Validators;
using System.Reflection;

namespace Shapes.AreaCalculator;

public static class DependencyInjection
{
    public static IServiceCollection AddShapesAreaCalculator(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var requestsImplementations = assembly.GetTypes().Where(x => typeof(IAreaRequest).IsAssignableFrom(x) && !x.IsInterface).ToList();

        foreach (var requestType in requestsImplementations)
        {
            var concreteCalculator = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType 
                                                    && i.GetGenericTypeDefinition() == typeof(IAreaCalculator<>) 
                                                    && i.GetGenericArguments()[0] == requestType))
                .Single();

            var calculatorType = typeof(IAreaCalculator<>).MakeGenericType(requestType);
            services.AddTransient(calculatorType, concreteCalculator);
        }
        
        services.AddTransient<IArea, Area>();

        services.AddRequestValidators(assembly);

        return services;
    }

    /// <summary>
    /// Регистрирует все валидаторы в сборке
    /// </summary>
    private static IServiceCollection AddRequestValidators(this IServiceCollection services, Assembly assembly)
    {
        var requestsImplementations = assembly.GetTypes().Where(x => typeof(IAreaRequest).IsAssignableFrom(x) && !x.IsInterface).ToList();

        foreach (var requestType in requestsImplementations)
        {
            var concreteCalculator = assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType
                                                    && i.GetGenericTypeDefinition() == typeof(IRequestValidator<>)
                                                    && i.GetGenericArguments()[0] == requestType))
                .SingleOrDefault();

            var calculatorType = typeof(IRequestValidator<>).MakeGenericType(requestType);

            if (concreteCalculator != null)
                services.AddTransient(calculatorType, concreteCalculator);
        }

        return services;
    }
}