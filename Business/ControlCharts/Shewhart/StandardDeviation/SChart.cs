namespace Business.ControlCharts.StandardDeviation;

public class SChart(List<ISubgroup> subgroups) : XrsChart(subgroups)
{
    private static readonly Dictionary<int, (decimal B3, decimal B4)>
        Coefficients = new()
        {
            { 2, (0, 3.267m) },
            { 3, (0, 2.568m) },
            { 4, (0, 2.266m) },
            { 5, (0, 2.089m) },
            { 6, (0.03m, 1.97m) },
            { 7, (0.118m, 1.882m) },
            { 8, (0.185m, 1.815m) },
            { 9, (0.239m, 1.761m) },
            { 10, (0.284m, 1.716m) },
            { 11, (0.321m, 1.679m) },
            { 12, (0.354m, 1.646m) },
            { 13, (0.382m, 1.618m) },
            { 14, (0.406m, 1.594m) },
            { 15, (0.428m, 1.572m) },
            { 16, (0.448m, 1.552m) },
            { 17, (0.466m, 1.534m) },
            { 18, (0.482m, 1.518m) },
            { 19, (0.497m, 1.503m) },
            { 20, (0.51m, 1.49m) },
            { 21, (0.523m, 1.477m) },
            { 22, (0.534m, 1.466m) },
            { 23, (0.545m, 1.455m) },
            { 24, (0.555m, 1.445m) },
            { 25, (0.565m, 1.435m) }
        };

    public override void Calculate()
    {
        Points = [.. Subgroups.Select(s => s.StandardDeviation)];
        var standardDeviationMean = Points.Average();
        var (B3, B4) = Coefficients[SubgroupSize];
        CenterLine = standardDeviationMean;
        LowerControlLine = B3 * standardDeviationMean;
        UpperControlLine = B4 * standardDeviationMean;
    }
}