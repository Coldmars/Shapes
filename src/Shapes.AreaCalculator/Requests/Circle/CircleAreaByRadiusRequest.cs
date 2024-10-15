namespace Shapes.AreaCalculator.Requests.Circle;

/// <summary>
/// Запрос на вычисление площади круга, используя радиус
/// </summary>
/// <param name="radius">Радиус окружности</param>
public class CircleAreaByRadiusRequest(double radius) : IAreaRequest
{
    public double Radius { get; } = radius;
}