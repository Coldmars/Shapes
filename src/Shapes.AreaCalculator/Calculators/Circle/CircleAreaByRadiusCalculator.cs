using Shapes.AreaCalculator.Requests.Circle;
using Shapes.AreaCalculator.Validators;

namespace Shapes.AreaCalculator.Calculators.Circle;

/// <summary>
/// Калькулятор, вычисляющий площадь круга, используя радиус. Выполняется по запросу <see cref="CircleAreaByRadiusRequest"/>
/// </summary>
internal class CircleAreaByRadiusCalculator : IAreaCalculator<CircleAreaByRadiusRequest>
{
    private readonly IRequestValidator<CircleAreaByRadiusRequest> _validator;

    public CircleAreaByRadiusCalculator(IRequestValidator<CircleAreaByRadiusRequest> validator) => _validator = validator;

    public double Calculate(CircleAreaByRadiusRequest request)
    {
        _validator.ThrowIfInvalid(request);

        return Math.PI * request.Radius * request.Radius;
    }
}