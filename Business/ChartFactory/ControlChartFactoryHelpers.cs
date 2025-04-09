namespace Business
{
    static class ControlChartFactoryHelpers<T> where T: IValue<T>
    {
        public static T GetParameterValue(Dictionary<string, decimal> parameters, string key)
        {
            if (!parameters.TryGetValue(key, out var value))
                throw new ArgumentException(
                    $"{key} value should be provided for calculating the control chart with pre-specified values.");
            return (T)ValueFactory.CreateValue<T>(value);
        }
    }
}
