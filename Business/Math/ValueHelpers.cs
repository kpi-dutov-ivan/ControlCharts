using Business.ControlCharts;

namespace Business;

public static class ValueHelpers<T> where T : IValue<T>
{
    public static T CalculateAverage(List<T> data)
    {
        var sum = data.Aggregate((acc, value) => acc.Add(value));
        if (sum is null)
            throw new NullReferenceException();
        return sum.DivideCount(data.Count);
    }

    public static T CalculateSubgroupAverage(List<ISubgroup<T>> data, Func<ISubgroup<T>, T> selector)
    {
        var subgroupData = data.Select(selector).ToList();
        return CalculateAverage(subgroupData);
    }
}