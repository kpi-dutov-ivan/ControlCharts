using System.Globalization;

namespace Business;

public class PreciseValue : IPreciseValue<PreciseValue>
{
    public string RawValue { get; }
    public decimal NumberValue { get; }
    public int DecimalPlaces { get; }
    public int SignificantDigits { get; }
    
    public PreciseValue(string rawValue, int? decimalPlaces = null)
    {
        if (string.IsNullOrEmpty(rawValue))
            throw new ArgumentNullException(nameof(rawValue), "Raw value cannot be null or empty.");
        rawValue = rawValue.Trim();
        if (!decimal.TryParse(rawValue, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal value))
        {
            throw new ArgumentException("Invalid decimal value.", nameof(rawValue));
        }

        RawValue = rawValue;
        NumberValue = value;
        DecimalPlaces = decimalPlaces ?? DetermineDecimalPlaces(rawValue);
        SignificantDigits = DetermineSignificantFigures(rawValue);
    }

    private PreciseValue(decimal value, int decimalPlaces)
    {
        RawValue = value.ToString($"F{decimalPlaces}");
        NumberValue = value;
        DecimalPlaces = decimalPlaces;
        SignificantDigits = DetermineSignificantFigures(RawValue);
    }

    public static int DetermineSignificantFigures(string number)
    {
        var significantDigits = 0;
        var prevSignificant = false;
        var sandwichZeroCount = 0;
        
        foreach(var digit in number)
        {
            if (!char.IsDigit(digit))
            {
                if (digit is 'e' or 'E')
                {
                    break;
                }
                if (digit is '.' or '+' or '-')
                {
                    continue;
                }
               
                break;
            }
            
            if (digit == '0')
            {
                sandwichZeroCount++;
            }
            else
            {
                if (sandwichZeroCount > 0 && prevSignificant)
                {
                    significantDigits += sandwichZeroCount;
                    significantDigits++;
                    sandwichZeroCount = 0;
                }
                else
                {
                    if (!prevSignificant)
                    {
                        sandwichZeroCount = 0;
                        prevSignificant = true;
                    }
                    significantDigits++;
                }
            }
        }
        
        if (sandwichZeroCount > 0)
        {
            significantDigits += sandwichZeroCount;
        }
        
        return significantDigits;
    }
    
    public static int DetermineDecimalPlaces(string number)
    {
        if (string.IsNullOrEmpty(number))
            throw new ArgumentNullException(nameof(number), "Number cannot be null or empty.");
        
        var decimalIndex = number.IndexOf('.');
        if (decimalIndex == -1)
            return 0;
        
        var decimalSciencePart = number.Substring(decimalIndex + 1);
        var ePosition = decimalSciencePart.IndexOf('e');
        if (ePosition == -1)
        {
            return decimalSciencePart.Length;
        }
        var decimalPart = decimalSciencePart.Substring(0, ePosition);
        var multiplierString = decimalSciencePart.Substring(ePosition + 1);
        if (!int.TryParse(multiplierString, out var multiplier))
        {
            throw new ArgumentException("Invalid scientific notation.", nameof(number));
        }

        // TODO: Check for something more than the allowed decimal precision
        var decimalPlaces = decimalPart.Length - multiplier;
        
        if (decimalPlaces < 0)
            return 0;
        return decimalPlaces;
    }
    
    public static implicit operator decimal(PreciseValue preciseValue)
    {
        return preciseValue.NumberValue;
    }

    public PreciseValue Add(PreciseValue right)
    {
        var left = this;
        var leastPrecision = Math.Min(left.DecimalPlaces, right.DecimalPlaces);
        return new PreciseValue(left.NumberValue + right.NumberValue, leastPrecision);
    }
    
    public PreciseValue Subtract(PreciseValue right)
    {
        var left = this;
        var leastPrecision = Math.Min(left.DecimalPlaces, right.DecimalPlaces);
        return new PreciseValue(left.NumberValue - right.NumberValue, leastPrecision);
    }
    
    public PreciseValue Multiply(PreciseValue right)
    {
        var left = this;
        var leastSignificantDigits = Math.Min(left.SignificantDigits, right.SignificantDigits);
        return new PreciseValue(left.NumberValue * right.NumberValue, leastSignificantDigits);
    }

    public PreciseValue Multiply(decimal value)
    {
        throw new NotImplementedException();
    }

    public PreciseValue Divide(PreciseValue right)
    {
        if (right.NumberValue == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        var left = this;
        var leastSignificantDigits = Math.Min(left.SignificantDigits, right.SignificantDigits);
        return new PreciseValue(left.NumberValue / right.NumberValue, leastSignificantDigits);
    }

    public PreciseValue Divide(decimal value)
    {
        throw new NotImplementedException();
    }

    // TODO: Test
    public PreciseValue Sqrt()
    {
        var sqrtVal = (decimal)Math.Sqrt((double)this.NumberValue);

        // Round to the same number of significant digits
        var rounded = RoundToSignificantFigures(sqrtVal, this.SignificantDigits);

        // Reconstruct raw string to preserve significance
        var raw = FormatWithSignificantDigits(rounded, this.SignificantDigits);

        return new PreciseValue(raw);
    }
    
    private static decimal RoundToSignificantFigures(decimal num, int n)
    {
        if (num == 0)
            return 0;

        var d = Math.Ceiling(Math.Log10((double)Math.Abs(num)));
        var power = n - (int)d;

        var magnitude = (decimal)Math.Pow(10, power);
        var shifted = Math.Round(num * magnitude);
        return shifted / magnitude;
    }

    private static string FormatWithSignificantDigits(decimal num, int sigDigits)
    {
        return num.ToString("G" + sigDigits, CultureInfo.InvariantCulture);
    }

    public PreciseValue Abs()
    {
        throw new NotImplementedException();
    }
}