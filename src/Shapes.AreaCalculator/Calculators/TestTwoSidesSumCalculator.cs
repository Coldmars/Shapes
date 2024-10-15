using Shapes.AreaCalculator.Requests;

namespace Shapes.AreaCalculator.Calculators;

internal class TestTwoSidesSumCalculator : IAreaCalculator<TestTwoSidesSumRequest>
{
    public double Calculate(TestTwoSidesSumRequest request)
    {
        return request.FirstSide + request.SecondSide;
    }
}