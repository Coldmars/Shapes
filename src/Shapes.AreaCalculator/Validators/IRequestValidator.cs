using Shapes.AreaCalculator.Exceptions;

namespace Shapes.AreaCalculator.Validators;

/// <summary>
/// Определяет валидаторы конкретного запроса на вычисление площади
/// </summary>
internal interface IRequestValidator<in TRequest>
    where TRequest : IAreaRequest
{
    /// <summary>
    /// Валидирует запрос на возможность существования фигуры и/или вычисления площади
    /// </summary>
    /// <param name="request">Запрос на вычисление площади</param>
    /// <exception cref="ShapeException"/>
    void ThrowIfInvalid(TRequest request);
}