using Microsoft.Extensions.DependencyInjection;

namespace Shapes.AreaCalculator;

internal class Area : IArea
{
    private readonly IServiceProvider _serviceProvider;

    public Area(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public double Calculate<TAreaRequest>(TAreaRequest request) where TAreaRequest : IAreaRequest
        => _serviceProvider.GetServices<IAreaCalculator<TAreaRequest>>().Single().Calculate(request);
}