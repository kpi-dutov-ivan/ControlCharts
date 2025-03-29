namespace Business.ControlCharts.StandardDeviation;

public class SChartPreSpecified(List<Subgroup> subgroups, double sigma0) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, (double B5, double B6, double c4)> Coefficients = new()
    {
        { 2, (0, 2.606, 0.7979) },
        { 3, (0, 2.276, 0.8862) },
        { 4, (0, 2.088, 0.9213) },
        { 5, (0, 1.964, 0.94) },
        { 6, (0.029, 1.874, 0.9515) },
        { 7, (0.113, 1.806, 0.9594) },
        { 8, (0.179, 1.751, 0.965) },
        { 9, (0.232, 1.707, 0.9693) },
        { 10, (0.276, 1.669, 0.9727) },
        { 11, (0.313, 1.637, 0.9754) },
        { 12, (0.346, 1.61, 0.9776) },
        { 13, (0.374, 1.585, 0.9794) },
        { 14, (0.399, 1.563, 0.981) },
        { 15, (0.421, 1.544, 0.9823) },
        { 16, (0.44, 1.526, 0.9835) },
        { 17, (0.458, 1.511, 0.9845) },
        { 18, (0.475, 1.496, 0.9854) },
        { 19, (0.49, 1.483, 0.9862) },
        { 20, (0.504, 1.47, 0.9869) },
        { 21, (0.516, 1.459, 0.9876) },
        { 22, (0.528, 1.448, 0.9882) },
        { 23, (0.539, 1.438, 0.9887) },
        { 24, (0.549, 1.429, 0.9892) },
        { 25, (0.559, 1.42, 0.9896) }
    };

    public double Sigma0 { get; } = sigma0;

    public override void Calculate(List<Subgroup> subgroups)
    {
        Values = [.. subgroups.Select(s => s.StandardDeviation)];
        var (B5, B6, c4) = Coefficients[SubgroupSize];
        CenterLine = c4 * Sigma0;
        LowerControlLine = B5 * Sigma0;
        LowerControlLine = B6 * Sigma0;
    }
}