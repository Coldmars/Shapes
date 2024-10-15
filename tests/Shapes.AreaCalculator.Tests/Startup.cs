using Microsoft.Extensions.DependencyInjection;

namespace Shapes.AreaCalculator.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddShapesAreaCalculator();
    }
}