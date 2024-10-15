namespace Shapes.AreaCalculator.Requests;

public class TestTwoSidesSumRequest : IAreaRequest
{
    public int FirstSide { get; set; }

    public int SecondSide { get; set; }
}