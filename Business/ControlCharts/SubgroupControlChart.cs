namespace Business.ControlCharts
{
    public abstract class SubgroupControlChart : ControlChart
    {
        private const int DynamicSubgroupSize = int.MaxValue;
        public int SubgroupSize { get; protected set; }

        protected List<Subgroup> Subgroups;
        protected SubgroupControlChart(List<Subgroup> subgroups) : base()
        {
            InitializeSubgroupSize(subgroups);
            Subgroups = [.. subgroups];
        }

        private void InitializeSubgroupSize(List<Subgroup> subgroups)
        {
            const int minSubgroupSize = 2;
            if (subgroups.Count < minSubgroupSize)
                throw new ArgumentException($"Cannot initialize chart with less than {minSubgroupSize} subgroups");
            CalculateSubgroupSize(subgroups);
        }

        protected virtual void CalculateSubgroupSize(List<Subgroup> subgroups)
        {
            var firstSize = subgroups[0].Data.Count;
            if (subgroups.Any(s => s.Data.Count != firstSize))
                firstSize = DynamicSubgroupSize;
            SubgroupSize = firstSize;
        }

        public virtual void Update(List<Subgroup> subgroups)
        {
            CalculateSubgroupSize(subgroups);
            Calculate();
        }

    }
}
