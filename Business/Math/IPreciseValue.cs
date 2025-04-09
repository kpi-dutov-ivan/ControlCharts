namespace Business;

public interface IPreciseValue<T> : IValue<T> where T: IPreciseValue<T>
{
    string RawValue { get; }
    int DecimalPlaces { get; }
    int SignificantDigits { get; }
}