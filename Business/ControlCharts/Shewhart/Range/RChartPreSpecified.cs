namespace Business.ControlCharts.Range;

public class RChartPreSpecified<T>(List<ISubgroup<T>> subgroups, T sigma0) : XrsChart<T>(subgroups) where T : IValue<T>
{
    private static readonly Dictionary<int, (decimal D1, decimal D2, decimal d2)>
        Coefficients = new()
        {
            { 2, (0, 3.686m, 1.128m) },
            { 3, (0, 4.358m, 1.693m) },
            { 4, (0, 4.698m, 2.059m) },
            { 5, (0, 4.918m, 2.326m) },
            { 6, (0, 5.079m, 2.534m) },
            { 7, (0.205m, 5.204m, 2.704m) },
            { 8, (0.388m, 5.307m, 2.847m) },
            { 9, (0.547m, 5.394m, 2.97m) },
            { 10, (0.686m, 5.469m, 3.078m) },
            { 11, (0.811m, 5.535m, 3.173m) },
            { 12, (0.923m, 5.594m, 3.258m) },
            { 13, (1.025m, 5.647m, 3.336m) },
            { 14, (1.118m, 5.696m, 3.407m) },
            { 15, (1.203m, 5.74m, 3.472m) },
            { 16, (1.282m, 5.782m, 3.532m) },
            { 17, (1.356m, 5.82m, 3.588m) },
            { 18, (1.424m, 5.856m, 3.64m) },
            { 19, (1.489m, 5.889m, 3.689m) },
            { 20, (1.549m, 5.921m, 3.735m) },
            { 21, (1.606m, 5.951m, 3.778m) },
            { 22, (1.66m, 5.979m, 3.819m) },
            { 23, (1.711m, 6.006m, 3.858m) },
            { 24, (1.759m, 6.032m, 3.895m) },
            { 25, (1.805m, 6.056m, 3.931m) }
        };

    public T Sigma0 { get; } = sigma0;

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.Range)];
        var (D1, D2, d2) = Coefficients[SubgroupSize];
        CenterLine = Sigma0;
        LowerControlLine = Sigma0.Multiply(D1);
        UpperControlLine = Sigma0.Multiply(D2);
    }
}