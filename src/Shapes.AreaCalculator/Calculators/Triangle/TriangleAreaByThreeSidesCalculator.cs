using Shapes.AreaCalculator.Requests.Triangle;
using Shapes.AreaCalculator.Validators;

namespace Shapes.AreaCalculator.Calculators.Triangle;

/// <summary>
/// Калькулятор, вычисляющий площадь треугольника по трём сторонам. Выполняется по запросу <see cref="TriangleAreaByThreeSidesRequest"/>
/// </summary>
internal class TriangleAreaByThreeSidesCalculator : IAreaCalculator<TriangleAreaByThreeSidesRequest>
{
    private readonly IRequestValidator<TriangleAreaByThreeSidesRequest> _validator;

    public TriangleAreaByThreeSidesCalculator(IRequestValidator<TriangleAreaByThreeSidesRequest> validator) => _validator = validator;

    public double Calculate(TriangleAreaByThreeSidesRequest request)
    {
        _validator.ThrowIfInvalid(request);

        var halfPerimeter = (request.FirstSide + request.SecondSide + request.ThirdSide) / 2;
        var area = Math.Sqrt(halfPerimeter * (halfPerimeter - request.FirstSide) * (halfPerimeter - request.SecondSide) * (halfPerimeter - request.ThirdSide));

        return area;
    }
}