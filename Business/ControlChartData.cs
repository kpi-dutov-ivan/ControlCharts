namespace Business
{
    public class ControlChartData
    {
        // TODO: History?
        public List<ControlChart> Charts { get; } = [];
        public List<Subgroup> Data { get; } = [];

        public ControlChart Represent(ControlChartType chartType)
        {
            return ControlChartFactory.CreateControlChart(chartType, Data);
        }


    }
}
