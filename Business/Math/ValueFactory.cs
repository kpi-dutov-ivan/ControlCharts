namespace Business;

public static class ValueFactory
{
    public static T CreateValue<T>(decimal value) where T : IValue<T>
    {
        return (T)Activator.CreateInstance(typeof(T), value);
    }
    
    public static T CreateValue<T>(string value) where T : IValue<T>
    {
        if (typeof(T) == typeof(Value))
        {
            return (T)(IValue<Value>)new Value(value);
        } else if (typeof(T) == typeof(StatisticalValue))
        {
            return (T)(IValue<StatisticalValue>)new StatisticalValue(value);
        }
        
        throw new NotSupportedException($"Factory for type {typeof(T)} is not supported.");
    }
}