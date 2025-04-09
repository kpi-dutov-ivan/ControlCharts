namespace Business.ControlCharts.Defective
{
    public abstract class DefectiveControlChart<T> : IControlChart<T> where T: IValue<T>
    {
        public List<Defective> Defectives { get; }

        protected DefectiveControlChart(List<Defective> defectives)
        {
            if (defectives.Count < 2)
                throw new ArgumentException("Please provide at least two defectives to create a chart");
            Defectives = defectives;
        }

        public T CenterLine { get; set; }
        public T UpperControlLine { get; set; }
        public T LowerControlLine { get; set; }
        public List<T> Points { get; set; }
        public abstract void Calculate();
    }
}
