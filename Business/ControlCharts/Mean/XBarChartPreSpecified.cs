namespace Business.ControlCharts.Mean;

public class XBarChartPreSpecified(List<Subgroup> subgroups, double mu0, double sigma0) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, double> ACoefficients =
        new()
        {
            { 2, 2.121 },
            { 3, 1.732 },
            { 4, 1.5 },
            { 5, 1.342 },
            { 6, 1.225 },
            { 7, 1.134 },
            { 8, 1.061 },
            { 9, 1 },
            { 10, 0.949 },
            { 11, 0.905 },
            { 12, 0.866 },
            { 13, 0.832 },
            { 14, 0.802 },
            { 15, 0.775 },
            { 16, 0.75 },
            { 17, 0.728 },
            { 18, 0.707 },
            { 19, 0.688 },
            { 20, 0.671 },
            { 21, 0.655 },
            { 22, 0.64 },
            { 23, 0.626 },
            { 24, 0.612 },
            { 25, 0.6 }
        };

    public double Mu0 { get; } = mu0;

    public double Sigma0 { get; } = sigma0;

    // TODO: Show warnings on big values, suggest any errors?

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.Mean)];
        var threeSigma = ACoefficients[SubgroupSize] * Sigma0;
        CenterLine = Mu0;
        LowerControlLine = CenterLine - threeSigma;
        UpperControlLine = CenterLine + threeSigma;
    }
}