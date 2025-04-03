using Business.ControlCharts;

namespace Business;

public class DataProcessor(List<Subgroup> data, Dictionary<string, double> parameters)
{
    // TODO: History?
    public List<ControlChart> Charts { get; } = [];
    public List<Subgroup> Data { get; } = data;

}