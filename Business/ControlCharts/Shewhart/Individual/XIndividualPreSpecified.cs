namespace Business.ControlCharts.Individual
{
    class XIndividualPreSpecified<T>(List<T> individualValues, T mu0, T sigma0) : IndividualControlChart<T>(individualValues) where T: IValue<T>
    {
        public T Mu0 { get; private set; } = mu0;
        public T Sigma0 { get; private set; } = sigma0;

        public override void Calculate()
        {
            // TODO: How to ensure preservation of precision?
            var threeSigma = Sigma0.Multiply(3m);
            CenterLine = Mu0;
            LowerControlLine = CenterLine.Subtract(threeSigma);
            UpperControlLine = CenterLine.Add(threeSigma);
        }
    }
}