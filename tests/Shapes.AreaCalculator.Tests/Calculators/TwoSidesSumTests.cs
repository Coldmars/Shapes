using Shapes.AreaCalculator.Requests;

namespace Shapes.AreaCalculator.Tests.Calculators;

public class TwoSidesSumTests
{
    private readonly IArea _area;

    public TwoSidesSumTests(IArea area) => _area = area;

    [Fact]
    public void TwoSidesSumTest() 
    {
        var request = new TestTwoSidesSumRequest { FirstSide = 2, SecondSide = 3 };
        var expected = 5;

        var result = _area.Calculate(request);

        Assert.Equal(expected, result);
    }
}