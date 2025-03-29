namespace Business;

public class Subgroup
{
    public Subgroup(List<double> data)
    {
        Data = data;
        Mean = CalculateMean();
        StandardDeviation = CalculateStandardDeviation();
        Range = CalculateRange();
    }

    // TODO: Implement editing data.
    public List<double> Data { get; set; }
    public double Mean { get; }
    public double StandardDeviation { get; private set; }
    public double Range { get; private set; }

    private double CalculateMean()
    {
        return Data.Average();
    }

    private double CalculateStandardDeviation()
    {
        // TODO: Should it depend on Mean as being precalculated?
        var sum = 0.0;
        foreach (var value in Data)
        {
            var dif = value - Mean;
            sum += dif * dif;
        }

        return Math.Sqrt(sum / Data.Count);
    }

    private double CalculateRange()
    {
        return Data.Max() - Data.Min();
    }
}