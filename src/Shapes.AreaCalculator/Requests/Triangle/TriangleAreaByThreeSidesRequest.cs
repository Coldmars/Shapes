namespace Shapes.AreaCalculator.Requests.Triangle;

/// <summary>
/// Запрос на вычисление площади треугольника по трём сторонам
/// </summary>
/// <param name="firstSide">Первая сторона</param>
/// <param name="secondSide">Вторая сторона</param>
/// <param name="thirdSide">Третья сторона</param>
public class TriangleAreaByThreeSidesRequest(double firstSide, double secondSide, double thirdSide) : IAreaRequest
{
    public double FirstSide { get; } = firstSide;

    public double SecondSide { get; } = secondSide;

    public double ThirdSide { get; } = thirdSide;
}