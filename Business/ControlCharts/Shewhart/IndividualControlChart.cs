namespace Business.ControlCharts.Individual
{
    public abstract class IndividualControlChart : IControlChart
    {
        protected IndividualControlChart(List<decimal> individualValues)
        {
            Points = [.. individualValues];
        }

        public decimal CenterLine { get; set; }
        public decimal UpperControlLine { get; set; }
        public decimal LowerControlLine { get; set; }
        public List<decimal> Points { get; set; }
        public abstract void Calculate();
    }
}
