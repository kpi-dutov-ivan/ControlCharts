namespace Business.ControlCharts
{
    public interface IControlChart
    {
        public decimal CenterLine { get; }
        public decimal UpperControlLine { get; }
        public decimal LowerControlLine { get; }
        public List<decimal> Points { get; }

        public void Calculate();
    }
}