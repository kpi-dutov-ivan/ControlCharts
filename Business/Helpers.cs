namespace Business
{
    class Helpers
    {
        public static decimal GetParameterValue(Dictionary<string, decimal> parameters, string key)
        {
            if (!parameters.TryGetValue(key, out var value))
                throw new ArgumentException(
                    $"{key} value should be provided for calculating the control chart with pre-specified values.");
            return value;
        }
    }
}
