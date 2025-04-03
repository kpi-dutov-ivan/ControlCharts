namespace Business.ControlCharts.Individual
{
    public class RMChart(List<Subgroup> subgroups) : SubgroupControlChart(subgroups)
    {
        private const double Coefficient = 3.267;

        public override void Calculate()
        {
            base.Calculate();
            Points = [.. Subgroups.Zip(Subgroups.Skip(1), (a, b) => a.Data[0] - b.Data[0])];
            var movingRangeMean = Points.Average();
            CenterLine = movingRangeMean;
            LowerControlLine = 0;
            UpperControlLine = Coefficient * movingRangeMean;
        }
    }
}
