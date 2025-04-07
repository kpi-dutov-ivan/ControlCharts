namespace Business.ControlCharts.Individual
{
    public class RMChartPreSpecified : IndividualControlChart
    {
        private const decimal CentralLineCoefficient = 1.128m;
        private const decimal UpperControlLineCoefficient = 3.686m;
        private const decimal DefaultLowerControlLine = 0;

        public RMChartPreSpecified(List<decimal> individualValues, decimal sigma0) : base(individualValues)
        {
            Sigma0 = sigma0;
            Points = [.. individualValues.Zip(individualValues.Skip(1), (a, b) => a - b)];

        }

        public decimal Sigma0 { get; }

        public override void Calculate()
        {
            CenterLine = CentralLineCoefficient * Sigma0;
            LowerControlLine = DefaultLowerControlLine;
            UpperControlLine = UpperControlLineCoefficient * Sigma0;
        }
    }
}
