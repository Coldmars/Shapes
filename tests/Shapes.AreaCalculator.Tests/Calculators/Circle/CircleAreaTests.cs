using Shapes.AreaCalculator.Requests.Circle;

namespace Shapes.AreaCalculator.Tests.Calculators.Circle;

public class CircleAreaTests
{
    private readonly IArea _area;

    public CircleAreaTests(IArea area) => _area = area;

    /// <summary>
    /// Тест вычисления площади круга при валидном радиусе
    /// </summary>
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.1)]
    [InlineData(2.1, 13.9)]
    public void CircleArea_ByRadius_Valid(double radius, double expected)
    {
        // Arrange
        var request = new CircleAreaByRadiusRequest(radius);

        // Act
        var result = _area.Calculate(request);

        // Assert
        Assert.Equal(expected, result, 1);
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
    public void CircleArea_ByRadius_Null()
    {
        // Arrange
        CircleAreaByRadiusRequest request = null!;

        // Act & Assert
        Assert.Throws<ShapeException>(() => _area.Calculate(request));
    }
}