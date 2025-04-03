namespace Business.ControlCharts.Defective
{
    public class DefectiveControlChart : ControlChart
    {
        public List<Defective> Defectives { get; }

        public DefectiveControlChart(List<Defective> defectives)
        {
            if (defectives.Count < 2)
                throw new ArgumentException("Please provide at least two defectives to create a chart");
            Defectives = defectives;
        }
    }
}
