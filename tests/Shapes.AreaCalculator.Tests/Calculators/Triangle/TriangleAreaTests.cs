using Shapes.AreaCalculator.Requests.Triangle;

namespace Shapes.AreaCalculator.Tests.Calculators.Triangle;

public class TriangleAreaTests
{
    private readonly IArea _area;

    public TriangleAreaTests(IArea area) => _area = area;

    /// <summary>
    /// Тест вычисления площади треугольника по трём сторона при валидной передаче аргументов
    /// </summary>
    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(5, 6, 10, 11.4)]
    [InlineData(7.2, 6.3, 13.4, 5.5)]
    public void TriangleArea_ByThreeSides_Valid(double firstSide, double secondSide, double thirdSide, double expected)
    {
        // Arrange
        var request = new TriangleAreaByThreeSidesRequest(firstSide, secondSide, thirdSide);        

        // Act
        var result = _area.Calculate(request);

        // Assert
        Assert.Equal(expected, Math.Round(result, 1));
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

    /// <summary>
    /// Тест вычисления площади треугольника по трем сторонам, при передаче null запроса
    /// </summary>
    [Fact]
    public void TriangleArea_ByThreeSides_Null()
    {
        // Arrange
        TriangleAreaByThreeSidesRequest request = null!;

        // Act & Assert
        Assert.Throws<ShapeException>(() => _area.Calculate(request));
    }
}