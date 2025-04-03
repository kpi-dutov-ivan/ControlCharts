namespace Business.ControlCharts.Individual
{
    public class XIndividual(List<double> individualValues) : IndividualControlChart(individualValues)
    {
        private const double Coefficient = 2.66;

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
