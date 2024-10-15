namespace Shapes.AreaCalculator;

/// <summary>
/// Определяет соответствующий запросу калькулятор площади
/// </summary>
/// <typeparam name="TAreaRequest">Тип запроса</typeparam>
internal interface IAreaCalculator<in TAreaRequest> 
    where TAreaRequest : IAreaRequest
{
    /// <summary>
    /// Вычисляет площадь геометрической фигуры по соответствующему запросу
    /// </summary>
    /// <param name="request">Запрос на вычисление площади, содержащие данные о типе фигуре, её параметрах и т.д.</param>
    /// <returns></returns>
    double Calculate(TAreaRequest request);
}