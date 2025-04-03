namespace Business.ControlCharts.Range;

public class RChartPreSpecified(List<Subgroup> subgroups, double sigma0) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, (double D1, double D2, double d2)>
        Coefficients = new()
        {
            { 2, (0, 3.686, 1.128) },
            { 3, (0, 4.358, 1.693) },
            { 4, (0, 4.698, 2.059) },
            { 5, (0, 4.918, 2.326) },
            { 6, (0, 5.079, 2.534) },
            { 7, (0.205, 5.204, 2.704) },
            { 8, (0.388, 5.307, 2.847) },
            { 9, (0.547, 5.394, 2.97) },
            { 10, (0.686, 5.469, 3.078) },
            { 11, (0.811, 5.535, 3.173) },
            { 12, (0.923, 5.594, 3.258) },
            { 13, (1.025, 5.647, 3.336) },
            { 14, (1.118, 5.696, 3.407) },
            { 15, (1.203, 5.74, 3.472) },
            { 16, (1.282, 5.782, 3.532) },
            { 17, (1.356, 5.82, 3.588) },
            { 18, (1.424, 5.856, 3.64) },
            { 19, (1.489, 5.889, 3.689) },
            { 20, (1.549, 5.921, 3.735) },
            { 21, (1.606, 5.951, 3.778) },
            { 22, (1.66, 5.979, 3.819) },
            { 23, (1.711, 6.006, 3.858) },
            { 24, (1.759, 6.032, 3.895) },
            { 25, (1.805, 6.056, 3.931) }
        };

    public double Sigma0 { get; } = sigma0;

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.Range)];
        var (D1, D2, d2) = Coefficients[SubgroupSize];
        CenterLine = d2 * Sigma0;
        LowerControlLine = D1 * Sigma0;
        UpperControlLine = D2 * Sigma0;
    }
}