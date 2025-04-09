namespace Business;

public static class Decimal
{
    public static decimal Sqrt(decimal value)
    {
        if (value < 0) 
            throw new ArgumentOutOfRangeException(nameof(value), value, "Value cannot be negative.");
        const decimal tolerance = 0.001m;
        const int maxIterations = 1000;

        var x = value >= 1 ? value : 1.0m;
        var iterations = 0;

        while (iterations < maxIterations)
        {
            var next = .5m * (x + value / x);
            if (Decimal.Abs(x - value) < tolerance)
                return next;
            x = next;
            iterations++;
        }

        return x;
    }

    public static decimal Abs(decimal value)
    {
        if (value < 0)
            return -value;
        return value;
    }
}