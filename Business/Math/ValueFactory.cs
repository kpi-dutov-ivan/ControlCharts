namespace Business;

public static class ValueFactory
{
    public static IValue<T> CreateValue<T>(decimal value) where T : IValue<T>
    {
        return (IValue<T>)Activator.CreateInstance(typeof(T), value);
    }
}