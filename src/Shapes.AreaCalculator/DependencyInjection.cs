using Microsoft.Extensions.DependencyInjection;
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

        return services;
    }    
}