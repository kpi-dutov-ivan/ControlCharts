namespace Business;

public class Value : IValue<Value>
{
    public decimal NumberValue { get; }
    public Value(decimal value)
    {
        NumberValue = value;
    }
    
    public Value Subtract(Value value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return new Value(NumberValue - value.NumberValue);
    }

    public Value Add(Value value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return new Value(NumberValue + value.NumberValue);
    }

    public Value Multiply(Value value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return new Value(NumberValue * value.NumberValue);
    }

    public Value Multiply(decimal value)
    {
        throw new NotImplementedException();
    }

    public Value Divide(Value value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (value.NumberValue == 0) throw new DivideByZeroException();
        return NumberValue / value.NumberValue;
    }

    public Value Divide(decimal value)
    {
        return new Value(NumberValue / value);
    }

    public Value Sqrt()
    {
        if (NumberValue < 0) 
            throw new InvalidOperationException("Cannot calculate square root of a negative number.");
        
        const decimal tolerance = 0.001m;
        const int maxIterations = 1000;

        var x = NumberValue >= 1 ? NumberValue : 1.0m;
        var iterations = 0;

        while (iterations < maxIterations)
        {
            var next = .5m * (x + NumberValue / x);
            if (Math.Abs(x - NumberValue) < tolerance)
                return next;
            x = next;
            iterations++;
        }

        return x;
    }

    public Value Abs()
    {
        if (NumberValue < 0)
            return -NumberValue;
        return NumberValue;
    }
    
    public static implicit operator decimal(Value value) => value.NumberValue;
    public static implicit operator Value(decimal value) => new Value(value);
}