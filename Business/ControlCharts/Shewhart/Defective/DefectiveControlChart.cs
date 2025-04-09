namespace Business.ControlCharts.Defective
{
    public abstract class DefectiveControlChart : IControlChart
    {
        public List<Defective> Defectives { get; }

        protected DefectiveControlChart(List<Defective> defectives)
        {
            if (defectives.Count < 2)
                throw new ArgumentException("Please provide at least two defectives to create a chart");
            Defectives = defectives;
        }

        public decimal CenterLine { get; set; }
        public decimal UpperControlLine { get; set; }
        public decimal LowerControlLine { get; set; }
        public List<decimal> Points { get; set; }
        public abstract void Calculate();
    }
}
