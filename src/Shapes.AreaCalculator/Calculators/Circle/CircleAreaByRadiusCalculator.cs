using Shapes.AreaCalculator.Requests.Circle;

namespace Shapes.AreaCalculator.Calculators.Circle;

/// <summary>
/// Калькулятор, вычисляющий площадь круга, используя радиус. Выполняется по запросу <see cref="CircleAreaByRadiusRequest"/>
/// </summary>
internal class CircleAreaByRadiusCalculator : IAreaCalculator<CircleAreaByRadiusRequest>
{
    public double Calculate(CircleAreaByRadiusRequest request)
    {
        // TODO: validator

        return Math.PI * request.Radius * request.Radius;
    }
}