using Business;

namespace Tests.Math
{
    public class PreciseValueTestCase : IPreciseValue
    {
        public PreciseValueTestCase(string rawValue, decimal value, int decimalPlaces, int significantDigits)
        {
            RawValue = rawValue;
            Value = value;
            DecimalPlaces = decimalPlaces;
            SignificantDigits = significantDigits;
        }

        public string RawValue { get; }
        public decimal Value { get; }
        public int DecimalPlaces { get; }
        public int SignificantDigits { get; }
    }
}