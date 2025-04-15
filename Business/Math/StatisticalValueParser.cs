using System.Globalization;

namespace Business;

public enum DigitParsingAction
{
    Error,
    Skip,
    Stop,
    Count
}

public class SignificantDigitParser
{
    private string _rawValue;
    private List<int> _significantDigitIndices = new();
    private int _exponentIndex = -1;
    
    public string RawValue
    {
        get => _rawValue;
        private set => _rawValue = value;
    }

    public int SignificantFigures { get; private set; }
    public int DecimalPlaces { get; private set; }
    
    public decimal NumberValue { get; private set; }

    public SignificantDigitParser(decimal number)
    {
        _rawValue = FormatValue(number);
        Parse();
    }
    public SignificantDigitParser(string number)
    {
        _rawValue = number;
        Parse();
    }

    private void Parse()
    {
        AssignNumberValue();
        AssignSignificantFigures();
        AssignDecimalPlaces();
    }

    private void AssignNumberValue()
    {
        if (!decimal.TryParse(_rawValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
            throw new ArgumentException("Invalid number format.", nameof(_rawValue));
        
        NumberValue = number;
    }

    private void AssignSignificantFigures()
    {
        bool hasSeenNonZero = false;
        int sandwichZeros = 0;
        _significantDigitIndices.Clear();

        for (int i = 0; i < _rawValue.Length; i++)
        {
            char c = _rawValue[i];
            var action = GetActionForDigit(c);

            if (action == DigitParsingAction.Error)
                throw new InvalidOperationException("Invalid character in input.");

            if (action == DigitParsingAction.Stop)
            {
                _exponentIndex = i;
                break;
            }

            if (action == DigitParsingAction.Skip)
                continue;

            if (c == '0')
            {
                if (hasSeenNonZero)
                    sandwichZeros++;
            }
            else
            {
                if (!hasSeenNonZero)
                {
                    hasSeenNonZero = true;
                    _significantDigitIndices.Add(i);
                }
                else
                {
                    _significantDigitIndices.AddRange(Enumerable.Range(i - sandwichZeros, sandwichZeros + 1));
                    sandwichZeros = 0;
                }
            }
        }

        // If sandwich zeros at end
        if (sandwichZeros > 0)
        {
            _significantDigitIndices.AddRange(Enumerable.Range(
                _significantDigitIndices.LastOrDefault() + 1, sandwichZeros));
        }
        SignificantFigures = _significantDigitIndices.Count;
    }

    private void AssignDecimalPlaces()
    {
        var decimalIndex = _rawValue.IndexOf('.');
        if (decimalIndex == -1)
        {
            DecimalPlaces = 0;
            return;
        }

        var decimalSciencePart = _rawValue.Substring(decimalIndex + 1);
        var ePosition = decimalSciencePart.IndexOf('e');
        if (ePosition == -1)
        {
            DecimalPlaces = decimalSciencePart.Length;
            return;
        }
        var decimalPart = decimalSciencePart.Substring(0, ePosition);
        var multiplierString = decimalSciencePart.Substring(ePosition + 1);
        if (!int.TryParse(multiplierString, out var multiplier))
        {
            throw new ArgumentException("Invalid scientific notation.", nameof(_rawValue));
        }

        // TODO: Check for something more than the allowed decimal precision
        var decimalPlaces = decimalPart.Length - multiplier;

        if (decimalPlaces < 0)
        {
            DecimalPlaces = 0;
            return;
        }

        DecimalPlaces = decimalPlaces;
    }

    private DigitParsingAction GetActionForDigit(char c) =>
        char.IsDigit(c) ? DigitParsingAction.Count :
        c switch
        {
            '.' or '+' or '-' => DigitParsingAction.Skip,
            'e' or 'E' => DigitParsingAction.Stop,
            _ => DigitParsingAction.Error
        };
    
    public void RoundToSignificantFigures(int n)
    {
        if (n <= 0 || n > _significantDigitIndices.Count)
            throw new ArgumentOutOfRangeException(nameof(n), "Invalid number of significant digits");

        int roundIndex = _significantDigitIndices[n - 1];

        // Split mantissa and exponent
        string mantissa = _rawValue.Substring(0, _exponentIndex > 0 ? _exponentIndex : _rawValue.Length);
        string exponent = _exponentIndex > 0 ? _rawValue.Substring(_exponentIndex) : "";

        int decimalPointIndex = mantissa.IndexOf('.');
        int digitsAfterDecimal = roundIndex - decimalPointIndex;

        if (decimalPointIndex < 0)
        {
            // If there's no decimal point, add one at the end
            mantissa += '.';
            decimalPointIndex = mantissa.Length - 1;
            digitsAfterDecimal = roundIndex - decimalPointIndex;
        }

        // Perform rounding
        if (decimal.TryParse(mantissa, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal parsedMantissa))
        {
            decimal roundedValue = Math.Round(parsedMantissa, digitsAfterDecimal, MidpointRounding.AwayFromZero);
            RawValue = roundedValue.ToString(CultureInfo.InvariantCulture) + exponent;
            NumberValue = decimal.Parse(RawValue, CultureInfo.InvariantCulture);
            AssignSignificantFigures();
        }
        else
        {
            throw new FormatException("Unable to parse mantissa.");
        }
    }


    public void RoundToDecimalPlaces(int n)
    {
        var newValue = (decimal)Math.Round(NumberValue, n);
        RawValue = FormatValue(newValue);
        NumberValue = newValue;
        DecimalPlaces = n;
        AssignSignificantFigures();
    }
    
    public static string FormatValue(decimal value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }
}
