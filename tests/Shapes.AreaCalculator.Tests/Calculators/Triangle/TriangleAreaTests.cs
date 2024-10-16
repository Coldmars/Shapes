using Shapes.AreaCalculator.Exceptions;
using Shapes.AreaCalculator.Requests.Triangle;

namespace Shapes.AreaCalculator.Tests.Calculators.Triangle;

public class TriangleAreaTests
{
    private readonly IArea _area;

    public TriangleAreaTests(IArea area) => _area = area;

    /// <summary>
    /// Тест вычисления площади треугольника по трём сторона при валидной передаче аргументов
    /// </summary>
    [Fact]
    public void TriangleArea_ByThreeSides_Valid()
    {
        // Arrange
        var request = new TriangleAreaByThreeSidesRequest(3, 4, 5);
        var expected = 6;

        // Act
        var result = _area.Calculate(request);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Тест вычисления площади треугольника по трём сторона при не валидной передаче аргументов
    /// </summary>
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 4, 5)]
    [InlineData(3, 0, 5)]
    [InlineData(3, 4, 0)]    
    [InlineData(12, 5, 6)]
    [InlineData(4, 14, 3)]
    [InlineData(4, 5, 10)]
    [InlineData(-4, 3, 5)]
    [InlineData(4, -3, 5)]
    [InlineData(4, 3, -5)]
    [InlineData(-4.2, -5.1, -10.7)]
    public void TriangleArea_ByThreeSides_Invalid(double firstSide, double secondSide, double thirdSide)
    {
        // Arrange
        var request = new TriangleAreaByThreeSidesRequest(firstSide, secondSide, thirdSide);        

        // Act & Assert
        Assert.Throws<ShapeException>(() => _area.Calculate(request));        
    }
}