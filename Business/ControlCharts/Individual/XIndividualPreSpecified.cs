namespace Business.ControlCharts.Individual
{
    class XIndividualPreSpecified(List<double> individualValues, double mu0, double sigma0) : IndividualControlChart(individualValues)
    {
        public double Mu0 { get; private set; } = mu0;
        public double Sigma0 { get; private set; } = sigma0;

        public override void Calculate()
        {
            var threeSigma = 3 * Sigma0;
            CenterLine = Mu0;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }

    }
}