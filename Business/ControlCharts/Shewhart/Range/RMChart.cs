namespace Business.ControlCharts.Individual
{
    public class RMChart : IndividualControlChart
    {
        public RMChart(List<decimal> individualValues) : base(individualValues)
        {
            Points = [.. individualValues.Zip(individualValues.Skip(1), (a, b) => Decimal.Abs(a - b))];
        }

        private const decimal Coefficient = 3.267m;

        public override void Calculate()
        {
            var movingRangeMean = Points.Average();
            CenterLine = movingRangeMean;
            LowerControlLine = 0;
            UpperControlLine = Coefficient * movingRangeMean;
        }
    }
}
