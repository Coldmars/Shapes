using Shapes.AreaCalculator.Exceptions;
using Shapes.AreaCalculator.Requests.Triangle;

namespace Shapes.AreaCalculator.Validators.Triangle;

internal class TriangleAreaByThreeSidesRequestValidator : IRequestValidator<TriangleAreaByThreeSidesRequest>
{
    public void ThrowIfInvalid(TriangleAreaByThreeSidesRequest request)
    {
        if (request == null)
            throw new ShapeException("Request object must not be null.");

        if (request.FirstSide + request.SecondSide < request.ThirdSide ||
            request.SecondSide + request.ThirdSide < request.FirstSide ||
            request.ThirdSide + request.FirstSide < request.SecondSide)
            throw new ShapeException("This triangle cannot exist.");
    }
}