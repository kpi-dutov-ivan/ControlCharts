#nullable enable
namespace Business.ControlCharts.Individual
{
    public class XIndividual<T>(List<T> individualValues) : IndividualControlChart<T>(individualValues) where T: IValue<T>
    {
        private const decimal Coefficient = 2.66m;
        private RMChart<T>? _rmChart;

        public override void Calculate()
        {
            if (Points.Count < 2)
            {
                throw new ArgumentException("At least two points are required to calculate the control chart.");
            }
            
            if (_rmChart == null)
            {
                _rmChart = new RMChart<T>(Points);
                _rmChart.Calculate();
            }

            var valueMean = ValueHelpers<T>.CalculateAverage(Points);
            var movingRangeAverage = _rmChart.CenterLine;
            var threeSigma = movingRangeAverage.Multiply(Coefficient);
            CenterLine = valueMean;
            LowerControlLine = valueMean.Subtract(threeSigma);
            UpperControlLine = valueMean.Add(threeSigma);
        }
    }

}
