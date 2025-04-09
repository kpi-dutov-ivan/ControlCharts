namespace Business.ControlCharts.Individual
{
    public class XIndividual(List<decimal> individualValues) : IndividualControlChart(individualValues)
    {
        private const decimal Coefficient = 2.66m;

        public override void Calculate()
        {
            var valueMean = Points.Average();
            var movingRangeAverage = Points.Zip(Points.Skip(1), (a, b) => a - b).Average();
            var threeSigma = movingRangeAverage * Coefficient;
            CenterLine = valueMean;
            LowerControlLine = valueMean - threeSigma;
            UpperControlLine = valueMean + threeSigma;
        }
    }

}
