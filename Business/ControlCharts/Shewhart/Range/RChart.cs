using Business.ControlCharts.Individual;
using Business.ControlCharts.Shewhart;

namespace Business.ControlCharts.Range;

public class RChart<T> : IndividualControlChart<T>, ISubgroupSized where T : IValue<T>
{
    public int SubgroupSize { get; }
    public RChart(List<T> individualValues, int subgroupSize) : base(individualValues)
    {
        SubgroupSize = subgroupSize;
    }

    private static readonly Dictionary<int, (decimal D3, decimal D4)>
        Coefficients = new()
        {
            { 2, (0, 3.267m) },
            { 3, (0, 2.575m) },
            { 4, (0, 2.282m) },
            { 5, (0, 2.114m) },
            { 6, (0, 2.004m) },
            { 7, (0.076m, 1.924m) },
            { 8, (0.136m, 1.864m) },
            { 9, (0.184m, 1.816m) },
            { 10, (0.223m, 1.777m) },
            { 11, (0.256m, 1.744m) },
            { 12, (0.283m, 1.717m) },
            { 13, (0.307m, 1.693m) },
            { 14, (0.328m, 1.672m) },
            { 15, (0.347m, 1.653m) },
            { 16, (0.363m, 1.637m) },
            { 17, (0.378m, 1.622m) },
            { 18, (0.391m, 1.609m) },
            { 19, (0.404m, 1.596m) },
            { 20, (0.415m, 1.585m) },
            { 21, (0.425m, 1.575m) },
            { 22, (0.435m, 1.567m) },
            { 23, (0.443m, 1.557m) },
            { 24, (0.452m, 1.548m) },
            { 25, (0.459m, 1.541m) }
        };

    public override void Calculate()
    {
        var rangeMean = ValueHelpers<T>.CalculateAverage(Points);
        var (D3, D4) = Coefficients[SubgroupSize];
        CenterLine = rangeMean;
        LowerControlLine = rangeMean.Multiply(D3);
        UpperControlLine = rangeMean.Multiply(D4);
    }
}