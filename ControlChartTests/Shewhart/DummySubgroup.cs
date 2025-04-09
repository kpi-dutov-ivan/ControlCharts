using Business.ControlCharts;

namespace Tests
{
    public class DummySubgroup : ISubgroup
    {
        public DummySubgroup(decimal mean = 0.0m, decimal range = 0.0m, int size = 0, decimal standardDeviation = 0,
            decimal median = 0.0m)
        {
            Mean = mean;
            Range = range;
            Size = size;
            StandardDeviation = standardDeviation;
            Median = median;
        }

        public decimal Mean { get; set; }
        public decimal Median { get; set; }
        public decimal StandardDeviation { get; set; }
        public decimal Range { get; set; }
        public int Size { get; }
    }
}