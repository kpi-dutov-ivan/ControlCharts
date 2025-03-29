namespace Business.ControlCharts
{
    public abstract class XRSChart : ControlChart
    {
        public int SubgroupSize { get; }
        protected XRSChart(List<Subgroup> subgroups)
        {
            if (subgroups.Count == 0)
            {
                throw new ArgumentException("Cannot create chart for empty subgroups");
            }

            const int maxSubgroupSize = 25;
            var subgroupSize = subgroups[0].Data.Count;

            if (subgroupSize > maxSubgroupSize)
            {
                throw new ArgumentException(
                    $"Don't have coefficients for subgroups with size greater than {maxSubgroupSize}, got {subgroupSize}", nameof(subgroups));
            }

            if (subgroups.Any(s => s.Data.Count != subgroupSize))
            {
                throw new ArgumentException("Use of subgroups of different sizes is not supported yet.");
            }

            SubgroupSize = subgroupSize;
            Values = [.. subgroups.Select(s => s.Mean)];
        }
    }
}
