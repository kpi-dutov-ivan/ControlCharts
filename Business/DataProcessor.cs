using Business.ControlCharts;

namespace Business;

public class DataProcessor(List<Subgroup> data, Dictionary<string, decimal> parameters)
{
    // TODO: History?
    public List<IControlChart> Charts { get; } = [];
    public List<Subgroup> Data { get; } = data;

}