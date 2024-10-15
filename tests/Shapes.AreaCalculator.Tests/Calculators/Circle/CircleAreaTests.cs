using Shapes.AreaCalculator.Requests.Circle;

namespace Shapes.AreaCalculator.Tests.Calculators.Circle;

public class CircleAreaTests
{
    private readonly IArea _area;

    public CircleAreaTests(IArea area) => _area = area;

    /// <summary>
    /// Тест вычисления площади круга при валидной передаче аргументов
    /// </summary>
    [Fact]
    public void CircleArea_ByRadius_Valid()
    {
        // Arrange
        var request = new CircleAreaByRadiusRequest(2.1);
        var expected = Math.Round(13.8544, 1); // PI = 3.1415926535

        // Act
        var result = _area.Calculate(request);

        // Assert
        Assert.Equal(expected, Math.Round(result, 1));
    }    
}