namespace Shapes.AreaCalculator;

/// <summary>
/// Определяет главный интерфейс для работы с калькулятором площади геометрической фигуры
/// </summary>
public interface IArea
{
    /// <summary>
    /// Вычисляет площадь геометрической фигуры по соответствующему запросу
    /// </summary>
    /// <param name="request">Запрос на вычисление площади, содержащие данные о типе фигуре, её параметрах и т.д.</param>
    /// <returns></returns>
    double Calculate<TAreaRequest>(TAreaRequest request) where TAreaRequest : IAreaRequest;
}