using Shapes.AreaCalculator.Requests.Triangle;

namespace Shapes.AreaCalculator.Calculators.Triangle;

/// <summary>
/// Калькулятор, вычисляющий площадь треугольника по трём сторонам. Выполняется по запросу <see cref="TriangleAreaByThreeSidesRequest"/>
/// </summary>
internal class TriangleAreaByThreeSidesCalculator : IAreaCalculator<TriangleAreaByThreeSidesRequest>
{
    public double Calculate(TriangleAreaByThreeSidesRequest request)
    {
        // TODO: validator

        var halfPerimeter = (request.FirstSide + request.SecondSide + request.ThirdSide) / 2;
        var area = Math.Sqrt(halfPerimeter * (halfPerimeter - request.FirstSide) * (halfPerimeter - request.SecondSide) * (halfPerimeter - request.ThirdSide));

        return area;
    }
}