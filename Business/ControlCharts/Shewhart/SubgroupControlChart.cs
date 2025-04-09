namespace Business.ControlCharts
{
    public abstract class SubgroupControlChart<T> : IControlChart<T> where T : IValue<T>
    {
        private const int DynamicSubgroupSize = int.MaxValue;
        public int SubgroupSize { get; protected set; }

        protected List<ISubgroup<T>> Subgroups;
        protected SubgroupControlChart(List<ISubgroup<T>> subgroups) : base()
        {
            InitializeSubgroupSize(subgroups);
            Subgroups = [.. subgroups];
        }

        private void InitializeSubgroupSize(List<ISubgroup<T>> subgroups)
        {
            const int minSubgroupSize = 2;
            if (subgroups.Count < minSubgroupSize)
                throw new ArgumentException($"Cannot initialize chart with less than {minSubgroupSize} subgroups");
            CalculateSubgroupSize(subgroups);
        }

        private void CalculateSubgroupSize(List<ISubgroup<T>> subgroups)
        {
            var firstSize = subgroups[0].Size;
            if (subgroups.Any(s => s.Size != firstSize))
                firstSize = DynamicSubgroupSize;
            SubgroupSize = firstSize;
        }

        public void Update(List<ISubgroup<T>> subgroups)
        {
            CalculateSubgroupSize(subgroups);
            Calculate();
        }

        public T CenterLine { get; set; }
        public T UpperControlLine { get; set; }
        public T LowerControlLine { get; set; }
        public List<T> Points { get; set; }
        public abstract void Calculate();
    }
}
