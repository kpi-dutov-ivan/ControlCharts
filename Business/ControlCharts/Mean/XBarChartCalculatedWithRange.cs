namespace Business.ControlCharts.Mean;

//TODO: In presentation layer show some hint on this being not good for something more than 10 or whatever.
public class XBarChartCalculatedWithRange(List<ISubgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, decimal> A2Coefficients =
        new()
        {
            { 2, 1.88m },
            { 3, 1.023m },
            { 4, 0.729m },
            { 5, 0.577m },
            { 6, 0.483m },
            { 7, 0.419m },
            { 8, 0.373m },
            { 9, 0.337m },
            { 10, 0.308m },
            { 11, 0.285m },
            { 12, 0.266m },
            { 13, 0.249m },
            { 14, 0.235m },
            { 15, 0.223m },
            { 16, 0.212m },
            { 17, 0.203m },
            { 18, 0.194m },
            { 19, 0.187m },
            { 20, 0.18m },
            { 21, 0.173m },
            { 22, 0.167m },
            { 23, 0.162m },
            { 24, 0.157m },
            { 25, 0.153m }
        };

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.Mean)];
        var subgroupAverage = Points.Average();
        var rangeAverage = Subgroups.Average(s => s.Range);
        // TODO: Exception handling
        var threeSigma = A2Coefficients[SubgroupSize] * rangeAverage;

        LowerControlLine = subgroupAverage - threeSigma;
        CenterLine = subgroupAverage;
        UpperControlLine = subgroupAverage + threeSigma;
    }
}