namespace Business.ControlCharts
{
    public interface IControlChart<T> where T : IValue<T>
    {
        public T CenterLine { get; }
        public T UpperControlLine { get; }
        public T LowerControlLine { get; }
        public List<T> Points { get; }

        public void Calculate();
    }
}