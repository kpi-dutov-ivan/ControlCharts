namespace Business.ControlCharts.Mean;

//TODO: In presentation layer show some hint on this being not good for something more than 10 or whatever.
public class XBarChartCalculatedWithRange(List<Subgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, double> A2Coefficients =
        new()
        {
            { 2, 1.88 },
            { 3, 1.023 },
            { 4, 0.729 },
            { 5, 0.577 },
            { 6, 0.483 },
            { 7, 0.419 },
            { 8, 0.373 },
            { 9, 0.337 },
            { 10, 0.308 },
            { 11, 0.285 },
            { 12, 0.266 },
            { 13, 0.249 },
            { 14, 0.235 },
            { 15, 0.223 },
            { 16, 0.212 },
            { 17, 0.203 },
            { 18, 0.194 },
            { 19, 0.187 },
            { 20, 0.18 },
            { 21, 0.173 },
            { 22, 0.167 },
            { 23, 0.162 },
            { 24, 0.157 },
            { 25, 0.153 }
        };

    public override void Calculate(List<Subgroup> subgroups)
    {
        base.Calculate(subgroups);
        var subgroupAverage = Values.Average();
        var rangeAverage = subgroups.Average(s => s.Range);
        var delta = A2Coefficients[SubgroupSize] * rangeAverage;

        LowerControlLine = subgroupAverage - delta;
        CenterLine = subgroupAverage;
        UpperControlLine = subgroupAverage + delta;
    }
}