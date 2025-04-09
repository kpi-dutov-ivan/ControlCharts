namespace Business.ControlCharts.Individual
{
    public class RMChart<T> : IndividualControlChart<T> where T : IValue<T>
    {
        public RMChart(List<T> individualValues) : base(individualValues)
        {
            Points = [.. individualValues.Zip(individualValues.Skip(1), (a, b) => a.Subtract(b).Abs())];
        }

        private const decimal Coefficient = 3.267m;

        public override void Calculate()
        {
            var movingRangeMean = ValueHelpers<T>.CalculateAverage(Points);
            CenterLine = movingRangeMean;
            LowerControlLine = default(T); // TODO: Factory!!!!
            UpperControlLine = movingRangeMean.Multiply(Coefficient);
        }
    }
}
