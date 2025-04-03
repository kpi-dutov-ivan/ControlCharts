namespace Business.ControlCharts.Individual
{
    public abstract class IndividualControlChart : ControlChart
    {
        protected IndividualControlChart(List<double> individualValues)
        {
            Points = [.. individualValues];
        }
    }
}
