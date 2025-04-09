using Business.ControlCharts;

namespace Business.ChartFactory;

public interface IControlChartFactory<T> where T : IValue<T>
{
    IControlChart<T> CreateControlChart(ControlChartType chartType,
        Dictionary<string, decimal> parameters);
}