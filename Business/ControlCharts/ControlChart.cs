namespace Business.ControlCharts;

public abstract class ControlChart
{
    protected List<Subgroup> _subgroups;
    public double CenterLine { get; protected set; }
    public double UpperControlLine { get; protected set; }
    public double LowerControlLine { get; protected set; }
    public List<double> Values { get; protected set; } = [];

    protected ControlChart(List<Subgroup> subgroups)
    {
        if (subgroups.Count < 2)
            throw new ArgumentException("Cannot initialize chart with less than 2 subgroups");
        _subgroups = subgroups;
    }

    public virtual void Calculate()
    {
    }

    public virtual void Update(List<Subgroup> subgroups)
    {
        _subgroups = subgroups;
        Calculate();
    }
}