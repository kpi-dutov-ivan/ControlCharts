namespace Business.ControlCharts.StandardDeviation;

public class SChart(List<Subgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, (double B3, double B4)>
        Coefficients = new()
        {
            { 2, (0, 3.267) },
            { 3, (0, 2.568) },
            { 4, (0, 2.266) },
            { 5, (0, 2.089) },
            { 6, (0.03, 1.97) },
            { 7, (0.118, 1.882) },
            { 8, (0.185, 1.815) },
            { 9, (0.239, 1.761) },
            { 10, (0.284, 1.716) },
            { 11, (0.321, 1.679) },
            { 12, (0.354, 1.646) },
            { 13, (0.382, 1.618) },
            { 14, (0.406, 1.594) },
            { 15, (0.428, 1.572) },
            { 16, (0.448, 1.552) },
            { 17, (0.466, 1.534) },
            { 18, (0.482, 1.518) },
            { 19, (0.497, 1.503) },
            { 20, (0.51, 1.49) },
            { 21, (0.523, 1.477) },
            { 22, (0.534, 1.466) },
            { 23, (0.545, 1.455) },
            { 24, (0.555, 1.445) },
            { 25, (0.565, 1.435) }
        };

    public override void Calculate()
    {
        Values = [.. _subgroups.Select(s => s.StandardDeviation)];
        var standardDeviationMean = Values.Average();
        var (B3, B4) = Coefficients[SubgroupSize];
        CenterLine = standardDeviationMean;
        LowerControlLine = B3 * standardDeviationMean;
        UpperControlLine = B4 * standardDeviationMean;
    }
}