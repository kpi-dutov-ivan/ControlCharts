namespace Business;

public interface IValue<T> : IEquatable<T> where T : IValue<T>
{
    public decimal NumberValue { get; }
    
    public T Subtract(T value);
    public T Add(T value);
    public T Multiply(T value);
    public T Multiply(decimal value);
    public T Divide(T value);
    public T DivideCount(int value);
    public T Sqrt();
    public T Abs();
}