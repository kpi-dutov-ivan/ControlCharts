namespace Business.ControlCharts
{
    public interface ISubgroup
    {
        public decimal Mean { get; }
        public decimal Median { get; }
        public decimal StandardDeviation { get; }
        public decimal Range { get; }
        public int Size { get; }
    }
}
