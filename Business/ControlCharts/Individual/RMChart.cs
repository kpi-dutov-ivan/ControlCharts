namespace Business.ControlCharts.Individual
{
    public class RMChart(List<Subgroup> subgroups) : ControlChart(subgroups)
    {
        private const double Coefficient = 3.267;

        public override void Calculate()
        {
            base.Calculate();
            Values = [.. _subgroups.Zip(_subgroups.Skip(1), (a, b) => a.Data[0] - b.Data[0])];
            var movingRangeMean = Values.Average();
            CenterLine = movingRangeMean;
            LowerControlLine = 0;
            UpperControlLine = Coefficient * movingRangeMean;
        }
    }
}
