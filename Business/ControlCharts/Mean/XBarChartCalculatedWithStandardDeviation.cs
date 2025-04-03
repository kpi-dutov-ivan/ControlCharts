namespace Business.ControlCharts.Mean;

public class XBarChartCalculatedWithStandardDeviation(List<Subgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, double> A3Coefficients =
        new()
        {
            { 2, 2.659 },
            { 3, 1.954 },
            { 4, 1.628 },
            { 5, 1.427 },
            { 6, 1.287 },
            { 7, 1.182 },
            { 8, 1.099 },
            { 9, 1.032 },
            { 10, 0.975 },
            { 11, 0.927 },
            { 12, 0.886 },
            { 13, 0.85 },
            { 14, 0.817 },
            { 15, 0.789 },
            { 16, 0.763 },
            { 17, 0.739 },
            { 18, 0.718 },
            { 19, 0.698 },
            { 20, 0.68 },
            { 21, 0.663 },
            { 22, 0.647 },
            { 23, 0.633 },
            { 24, 0.619 },
            { 25, 0.606 }
        };

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.Mean)];
        var subgroupMean = Subgroups.Average(s => s.Mean);
        var standardDeviationMean = Subgroups.Average(s => s.StandardDeviation);
        var threeSigma = A3Coefficients[SubgroupSize] * standardDeviationMean;
        LowerControlLine = subgroupMean - threeSigma;
        CenterLine = subgroupMean;
        UpperControlLine = subgroupMean + threeSigma;
    }
}