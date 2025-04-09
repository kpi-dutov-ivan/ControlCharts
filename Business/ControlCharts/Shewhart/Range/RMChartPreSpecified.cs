namespace Business.ControlCharts.Individual
{
    public class RMChartPreSpecified<T> : IndividualControlChart<T> where T: IValue<T>
    {
        private const decimal CentralLineCoefficient = 1.128m;
        private const decimal UpperControlLineCoefficient = 3.686m;
        private const decimal DefaultLowerControlLine = 0;

        public RMChartPreSpecified(List<T> individualValues, T sigma0) : base(individualValues)
        {
            Sigma0 = sigma0;
            Points = [.. individualValues.Zip(individualValues.Skip(1), (a, b) => a.Subtract(b).Abs())];

        }

        public T Sigma0 { get; }

        public override void Calculate()
        {
            CenterLine = Sigma0.Multiply(CentralLineCoefficient);
            LowerControlLine = Sigma0.Multiply(DefaultLowerControlLine);
            UpperControlLine = Sigma0.Multiply(UpperControlLineCoefficient);
        }
    }
}
