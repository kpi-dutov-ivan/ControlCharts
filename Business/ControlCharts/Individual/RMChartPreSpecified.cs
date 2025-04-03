namespace Business.ControlCharts.Individual
{
    public class RMChartPreSpecified(List<Subgroup> subgroups, double sigma0) : SubgroupControlChart(subgroups)
    {
        private const double CentralLineCoefficient = 1.128;
        private const double UpperControlLineCoefficient = 3.686;
        private const double DefaultLowerControlLine = 0;

        public double Sigma0 { get; } = sigma0;

        public override void Calculate()
        {
            base.Calculate();
            Points = [.. Subgroups.Zip(Subgroups.Skip(1), (a, b) => a.Data[0] - b.Data[0])];
            CenterLine = CentralLineCoefficient * Sigma0;
            LowerControlLine = DefaultLowerControlLine;
            UpperControlLine = UpperControlLineCoefficient * Sigma0;
        }
    }
}
