namespace Business.ControlCharts.Individual
{
    public class XIndividual(List<Subgroup> subgroups) : ControlChart(subgroups)
    {
        private ControlChart? _movingRangesChart;
        private const double Coefficient = 2.66;

        public override void Calculate()
        {
            _movingRangesChart ??= ControlChartFactory.CreateControlChart(ControlChartType.MovingRange, _subgroups, []);
            Values = [.. _subgroups.Select(s => s.Data[0])];
            var valueMean = Values.Average();
            var movingRangeAverage = _movingRangesChart.CenterLine; // center line is the mean of moving ranges.
            var delta = movingRangeAverage * Coefficient;
            CenterLine = valueMean;
            LowerControlLine = valueMean - delta;
            UpperControlLine = valueMean + delta;
        }

        public override void Update(List<Subgroup> subgroups)
        {
            base.Update(subgroups);
            if (_movingRangesChart == null)
                _movingRangesChart = ControlChartFactory.CreateControlChart(ControlChartType.MovingRange, subgroups, []);
            else
                _movingRangesChart.Update(subgroups);
        }
    }

}
