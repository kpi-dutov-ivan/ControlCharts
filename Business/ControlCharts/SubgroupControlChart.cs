namespace Business.ControlCharts
{
    public abstract class SubgroupControlChart : IControlChart
    {
        private const int DynamicSubgroupSize = int.MaxValue;
        public int SubgroupSize { get; protected set; }

        protected List<ISubgroup> Subgroups;
        protected SubgroupControlChart(List<ISubgroup> subgroups) : base()
        {
            InitializeSubgroupSize(subgroups);
            Subgroups = [.. subgroups];
        }

        private void InitializeSubgroupSize(List<ISubgroup> subgroups)
        {
            const int minSubgroupSize = 2;
            if (subgroups.Count < minSubgroupSize)
                throw new ArgumentException($"Cannot initialize chart with less than {minSubgroupSize} subgroups");
            CalculateSubgroupSize(subgroups);
        }

        protected void CalculateSubgroupSize(List<ISubgroup> subgroups)
        {
            var firstSize = subgroups[0].Size;
            if (subgroups.Any(s => s.Size != firstSize))
                firstSize = DynamicSubgroupSize;
            SubgroupSize = firstSize;
        }

        public void Update(List<ISubgroup> subgroups)
        {
            CalculateSubgroupSize(subgroups);
            Calculate();
        }

        public decimal CenterLine { get; set; }
        public decimal UpperControlLine { get; set; }
        public decimal LowerControlLine { get; set; }
        public List<decimal> Points { get; set; }
        public abstract void Calculate();
    }
}
