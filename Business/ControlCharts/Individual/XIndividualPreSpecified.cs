namespace Business.ControlCharts.Individual
{
    class XIndividualPreSpecified(List<Subgroup> subgroups, double mu0, double sigma0) : ControlChart(subgroups)
    {
        private ControlChart? _movingRangesChart;
        public double Mu0 { get; private set; } = mu0;
        public double Sigma0 { get; private set; } = sigma0;

        public override void Calculate()
        {
            _movingRangesChart ??= ControlChartFactory.CreateControlChart(ControlChartType.MovingRangePreSpecified, _subgroups, new()
            {
                ["sigma0"] = Sigma0
            });

            Values = [.. _subgroups.Select(s => s.Data[0])];
            var delta = 3 * Sigma0;
            CenterLine = Mu0;
            LowerControlLine = CenterLine - delta;
            UpperControlLine = CenterLine + delta;
        }

        public override void Update(List<Subgroup> subgroups)
        {
            _subgroups = subgroups;
            base.Update(_subgroups);

            if (_movingRangesChart == null)
            {
                _movingRangesChart = ControlChartFactory.CreateControlChart(ControlChartType.MovingRangePreSpecified, _subgroups, new()
                {
                    ["sigma0"] = Sigma0
                });
            }
            else
            {
                _movingRangesChart.Update(_subgroups);
            }
        }

        public void Update(double? mu0, double? sigma0)
        {
            if (mu0 != null)
                Mu0 = mu0.Value;
            if (sigma0 != null)
                Sigma0 = sigma0.Value;

            base.Update(_subgroups);
        }
    }
}