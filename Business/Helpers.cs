namespace Business
{
    class Helpers
    {
        public static double GetParameterValue(Dictionary<string, double> parameters, string key)
        {
            if (!parameters.TryGetValue(key, out var value))
                throw new ArgumentException(
                    $"{key} value should be provided for calculating the control chart with pre-specified values.");
            return value;
        }
    }
}
