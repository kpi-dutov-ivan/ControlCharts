namespace Business;

public interface IPreciseValue
{
    string RawValue { get; }
    decimal Value { get; }
    int DecimalPlaces { get; }
    int SignificantDigits { get; }
}