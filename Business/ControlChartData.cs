using Business.ControlCharts;

namespace Business
{
    public class ControlChartData(List<Subgroup> data, Dictionary<string, double> parameters)
    {
        // TODO: History?
        public List<ControlChart> Charts { get; } = [];
        public List<Subgroup> Data { get; } = data;

        public Dictionary<string, double> ChartParameters { get; } = parameters;

        public ControlChart Represent(ControlChartType chartType)
        {
            return ControlChartFactory.CreateControlChart(chartType, Data, ChartParameters);
        }

    }
}
