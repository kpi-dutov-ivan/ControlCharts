namespace Business.ControlCharts;

public abstract class ControlChart
{
    public double CenterLine { get; protected set; }
    public double UpperControlLine { get; protected set; }
    public double LowerControlLine { get; protected set; }
    public List<double> Points { get; protected set; } = [];

    public virtual void Calculate()
    {
    }

}