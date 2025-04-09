namespace Business.ControlCharts;

public abstract class XrsChart : SubgroupControlChart
{
    protected XrsChart(List<ISubgroup> subgroups) : base(subgroups)
    {
        const int maxSubgroupSize = 25;
        var subgroupSize = subgroups[0].Size;

        if (subgroupSize > maxSubgroupSize)
            throw new ArgumentException(
                $"Don't have coefficients for subgroups with size greater than {maxSubgroupSize}, got {subgroupSize}",
                nameof(subgroups));

        if (subgroups.Any(s => s.Size != subgroupSize))
            throw new ArgumentException("Use of subgroups of different sizes is not supported yet.");

        SubgroupSize = subgroupSize;
    }
}