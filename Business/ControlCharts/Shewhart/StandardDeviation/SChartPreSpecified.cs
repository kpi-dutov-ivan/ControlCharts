namespace Business.ControlCharts.StandardDeviation;

public class SChartPreSpecified(List<ISubgroup> subgroups, decimal sigma0) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, (decimal B5, decimal B6, decimal c4)> Coefficients = new()
    {
        { 2, (0, 2.606m, 0.7979m) },
        { 3, (0, 2.276m, 0.8862m) },
        { 4, (0, 2.088m, 0.9213m) },
        { 5, (0, 1.964m, 0.94m) },
        { 6, (0.029m, 1.874m, 0.9515m) },
        { 7, (0.113m, 1.806m, 0.9594m) },
        { 8, (0.179m, 1.751m, 0.965m) },
        { 9, (0.232m, 1.707m, 0.9693m) },
        { 10, (0.276m, 1.669m, 0.9727m) },
        { 11, (0.313m, 1.637m, 0.9754m) },
        { 12, (0.346m, 1.61m, 0.9776m) },
        { 13, (0.374m, 1.585m, 0.9794m) },
        { 14, (0.399m, 1.563m, 0.981m) },
        { 15, (0.421m, 1.544m, 0.9823m) },
        { 16, (0.44m, 1.526m, 0.9835m) },
        { 17, (0.458m, 1.511m, 0.9845m) },
        { 18, (0.475m, 1.496m, 0.9854m) },
        { 19, (0.49m, 1.483m, 0.9862m) },
        { 20, (0.504m, 1.47m, 0.9869m) },
        { 21, (0.516m, 1.459m, 0.9876m) },
        { 22, (0.528m, 1.448m, 0.9882m) },
        { 23, (0.539m, 1.438m, 0.9887m) },
        { 24, (0.549m, 1.429m, 0.9892m) },
        { 25, (0.559m, 1.42m, 0.9896m) }
    };

    public decimal Sigma0 { get; } = sigma0;

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.StandardDeviation)];
        var (B5, B6, c4) = Coefficients[SubgroupSize];
        CenterLine = c4 * Sigma0;
        LowerControlLine = B5 * Sigma0;
        LowerControlLine = B6 * Sigma0;
    }
}