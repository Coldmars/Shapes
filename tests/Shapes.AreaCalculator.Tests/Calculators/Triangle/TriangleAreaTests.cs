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
}