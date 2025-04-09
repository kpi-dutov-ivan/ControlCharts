using Business.ControlCharts;

namespace Business.ChartFactory;

public interface IControlChartFactory
{
    IControlChart CreateControlChart(ControlChartType chartType,
        Dictionary<string, decimal> parameters);
}