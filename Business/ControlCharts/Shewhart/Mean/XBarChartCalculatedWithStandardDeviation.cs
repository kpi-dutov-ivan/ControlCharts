namespace Business.ControlCharts.Mean;

public class XBarChartCalculatedWithStandardDeviation(List<ISubgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, decimal> A3Coefficients =
        new()
        {
            { 2, 2.659m },
            { 3, 1.954m },
            { 4, 1.628m },
            { 5, 1.427m },
            { 6, 1.287m },
            { 7, 1.182m },
            { 8, 1.099m },
            { 9, 1.032m },
            { 10, 0.975m },
            { 11, 0.927m },
            { 12, 0.886m },
            { 13, 0.85m },
            { 14, 0.817m },
            { 15, 0.789m },
            { 16, 0.763m },
            { 17, 0.739m },
            { 18, 0.718m },
            { 19, 0.698m },
            { 20, 0.68m },
            { 21, 0.663m },
            { 22, 0.647m },
            { 23, 0.633m },
            { 24, 0.619m },
            { 25, 0.606m }
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