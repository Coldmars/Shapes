using Shapes.AreaCalculator.Exceptions;
using Shapes.AreaCalculator.Requests.Circle;

namespace Shapes.AreaCalculator.Tests.Calculators.Circle;

public class CircleAreaTests
{
    private readonly IArea _area;

    public CircleAreaTests(IArea area) => _area = area;

    /// <summary>
    /// Тест вычисления площади круга при валидном радиусе
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

    /// <summary>
    /// Тест вычисления площади круга при не валидном радиусе
    /// </summary>
    [Theory]    
    [InlineData(-1)]
    [InlineData(-2.1)]
    public void CircleArea_ByRadius_Invalid(double radius)
    {
        // Arrange
        var request = new CircleAreaByRadiusRequest(radius);

        // Act & Assert
        Assert.Throws<ShapeException>(() => _area.Calculate(request));
    }

    /// <summary>
    /// Тест вычисления площади круга при нулевом радиусе
    /// </summary>
    [Fact]
    public void CircleArea_ByRadius_Zero()
    {
        // Arrange
        var request = new CircleAreaByRadiusRequest(0);
        var expected = 0;

        // Act
        var result = _area.Calculate(request);

        // Assert
        Assert.Equal(expected, result);
    }
}