namespace Business.ControlCharts.Individual
{
    class XIndividualPreSpecified(List<decimal> individualValues, decimal mu0, decimal sigma0) : IndividualControlChart(individualValues)
    {
        public decimal Mu0 { get; private set; } = mu0;
        public decimal Sigma0 { get; private set; } = sigma0;

        public override void Calculate()
        {
            var threeSigma = 3 * Sigma0;
            CenterLine = Mu0;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }

    }
}