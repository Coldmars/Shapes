namespace Shapes.AreaCalculator.Exceptions;

public class ShapeException : Exception
{
    public ShapeException()
    {
    }

    public ShapeException(string? message) : base(message)
    {
    }
}