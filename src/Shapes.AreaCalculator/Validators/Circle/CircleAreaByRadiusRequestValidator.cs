using Shapes.AreaCalculator.Exceptions;
using Shapes.AreaCalculator.Requests.Circle;

namespace Shapes.AreaCalculator.Validators.Circle;

/// <summary>
/// Валидириует запрос на вычисление площади окружности по радиусу
/// </summary>
internal class CircleAreaByRadiusRequestValidator : IRequestValidator<CircleAreaByRadiusRequest>
{
    public void ThrowIfInvalid(CircleAreaByRadiusRequest request)
    {
        if (request == null)
            throw new ShapeException("Request object must not be null.");

        if (request.Radius < 0)
            throw new ShapeException("Radius must not be less than zero.");
    }
}