using Business;
using Business.ControlCharts;

namespace Tests
{
    public class DummySubgroup<T> : ISubgroup<T> where T : IValue<T>
    {
        public DummySubgroup(string mean = "0.0", string range = "0.0", int size = 0, string standardDeviation = "0.0",
            string median = "0.0")
        {
            Mean = ValueFactory.CreateValue<T>(mean);
            Range = ValueFactory.CreateValue<T>(range);
            Size = size;
            StandardDeviation = ValueFactory.CreateValue<T>(standardDeviation);
            Median = ValueFactory.CreateValue<T>(median);
        }

        public T Mean { get; set; }
        public T Median { get; set; }
        public T StandardDeviation { get; set; }
        public T Range { get; set; }
        public int Size { get; }
    }
}