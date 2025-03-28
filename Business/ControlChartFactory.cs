namespace Business
{
    class ControlChartFactory
    {
        public static ControlChart CreateControlChart(ControlChartType chartType, List<Subgroup> subgroups)
        {
            return chartType switch
            {
                ControlChartType.Mean => new MeanMovingRangesChart(subgroups),
                ControlChartType.MovingRange => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(chartType), chartType, null)
            };
        }
    }
}
