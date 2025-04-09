namespace Business.ControlCharts.Individual
{
    public abstract class IndividualControlChart<T> : IControlChart<T> where T: IValue<T>
    {
        protected IndividualControlChart(List<T> individualValues)
        {
            Points = [.. individualValues];
        }

        public T CenterLine { get; set; }
        public T UpperControlLine { get; set; }
        public T LowerControlLine { get; set; }
        public List<T> Points { get; set; }
        public abstract void Calculate();
    }
}
