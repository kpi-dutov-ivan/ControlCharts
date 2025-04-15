using Business;

namespace Tests.Math
{
    public class PreciseValueTestCase<T> : IPreciseValue<T> where T : IPreciseValue<T>
    {
        private IPreciseValue<T> _preciseValueImplementation;

        public PreciseValueTestCase(string rawValue, decimal value, int decimalPlaces, int significantDigits)
        {
            RawValue = rawValue;
            NumberValue = value;
            DecimalPlaces = decimalPlaces;
            SignificantDigits = significantDigits;
        }

        public string RawValue { get; }
        public decimal NumberValue { get; }
        public T Subtract(T value)
        {
            return _preciseValueImplementation.Subtract(value);
        }

        public T Add(T value)
        {
            return _preciseValueImplementation.Add(value);
        }

        public T Multiply(T value)
        {
            return _preciseValueImplementation.Multiply(value);
        }

        public T Multiply(decimal value)
        {
            throw new System.NotImplementedException();
        }

        public T Divide(T value)
        {
            return _preciseValueImplementation.Divide(value);
        }

        public T DivideCount(int value)
        {
            return _preciseValueImplementation.DivideCount(value);
        }

        public T Sqrt()
        {
            return _preciseValueImplementation.Sqrt();
        }

        public T Abs()
        {
            return _preciseValueImplementation.Abs();
        }

        public int DecimalPlaces { get; }
        public int SignificantDigits { get; }
        public bool Equals(T other)
        {
            throw new System.NotImplementedException();
        }
    }
}