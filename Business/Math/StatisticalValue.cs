using System.Globalization;

namespace Business;

public class StatisticalValue : IPreciseValue<StatisticalValue>
{
    private readonly SignificantDigitParser _parser;
    public int DecimalPlaces => _parser.DecimalPlaces;
    public int SignificantDigits => _parser.SignificantFigures;
    public string RawValue => _parser.RawValue;
    public decimal NumberValue => _parser.NumberValue;

    public StatisticalValue RoundToSignificantDigits(int digits)
    {
        _parser.RoundToSignificantFigures(digits);
        return this;
    }
    
    public StatisticalValue RoundToDecimalPlaces(int decimalPlaces)
    {
        _parser.RoundToDecimalPlaces(decimalPlaces);
        return this;
    }

    public StatisticalValue(decimal value)
    {
        _parser = new SignificantDigitParser(value);
    }

    public StatisticalValue(string rawValue)
    {
        if (string.IsNullOrEmpty(rawValue))
            throw new ArgumentNullException(nameof(rawValue), "Raw value cannot be null or empty.");
        
        _parser = new SignificantDigitParser(rawValue);
    }
    
    public static implicit operator decimal(StatisticalValue statisticalValue)
    {
        return statisticalValue.NumberValue;
    }

    public StatisticalValue Add(StatisticalValue right)
    {
        var left = this;
        var leastDecimalPlaces = Math.Min(left.DecimalPlaces, right.DecimalPlaces);
        var newValue = left.NumberValue + right.NumberValue;
        return new StatisticalValue(newValue).RoundToDecimalPlaces(leastDecimalPlaces);
    }
    
    public StatisticalValue Subtract(StatisticalValue right)
    {
        var left = this;
        var leastPrecision = Math.Min(left.DecimalPlaces, right.DecimalPlaces);
        var newValue = left.NumberValue - right.NumberValue;
        return new StatisticalValue(newValue).RoundToDecimalPlaces(leastPrecision);
    }
    
    public StatisticalValue Multiply(StatisticalValue right)
    {
        var left = this;
        var leastSignificantDigits = Math.Min(left.SignificantDigits, right.SignificantDigits);
        var newValue = left.NumberValue * right.NumberValue;
        return new StatisticalValue(newValue).RoundToSignificantDigits(leastSignificantDigits);
    }

    public StatisticalValue Multiply(decimal value)
    {
        throw new NotImplementedException();
    }

    public StatisticalValue Divide(StatisticalValue right)
    {
        if (right.NumberValue == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        var left = this;
        var leastSignificantDigits = Math.Min(left.SignificantDigits, right.SignificantDigits);
        var result = left.NumberValue / right.NumberValue;
        return new StatisticalValue(result).RoundToSignificantDigits(leastSignificantDigits);
    }

    public StatisticalValue DivideCount(int value)
    {
        if (value == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        var left = this;
        var result = left.NumberValue / value;
        return new StatisticalValue(result).RoundToSignificantDigits(left.SignificantDigits);
    }

    // TODO: Test
    public StatisticalValue Sqrt()
    {
        var value = (decimal)Math.Sqrt((double)NumberValue);
        return new StatisticalValue(value).RoundToSignificantDigits(SignificantDigits);
    }

    public StatisticalValue Abs()
    {
        throw new NotImplementedException();
    }

    public bool Equals(StatisticalValue other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return RawValue == other.RawValue && NumberValue == other.NumberValue && DecimalPlaces == other.DecimalPlaces && SignificantDigits == other.SignificantDigits;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((StatisticalValue)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (RawValue != null ? RawValue.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ NumberValue.GetHashCode();
            hashCode = (hashCode * 397) ^ DecimalPlaces;
            hashCode = (hashCode * 397) ^ SignificantDigits;
            return hashCode;
        }
    }
}