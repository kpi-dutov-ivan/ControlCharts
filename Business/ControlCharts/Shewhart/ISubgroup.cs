namespace Business.ControlCharts
{
    public interface ISubgroup<T> where T : IValue<T>
    {
        public T Mean { get; }
        public T Median { get; }
        public T StandardDeviation { get; }
        public T Range { get; }
        public int Size { get; }
    }
}
