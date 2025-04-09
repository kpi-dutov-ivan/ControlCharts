namespace Business.ControlCharts.Mean
{
    public class XBarChartPreSpecified(List<ISubgroup> subgroups, decimal mu0, decimal sigma0) : XrsChart(subgroups)
    {
        private static readonly Dictionary<int, decimal> ACoefficients =
            new()
            {
                { 2, 2.121m },
                { 3, 1.732m },
                { 4, 1.5m },
                { 5, 1.342m },
                { 6, 1.225m },
                { 7, 1.134m },
                { 8, 1.061m },
                { 9, 1 },
                { 10, 0.949m },
                { 11, 0.905m },
                { 12, 0.866m },
                { 13, 0.832m },
                { 14, 0.802m },
                { 15, 0.775m },
                { 16, 0.75m },
                { 17, 0.728m },
                { 18, 0.707m },
                { 19, 0.688m },
                { 20, 0.671m },
                { 21, 0.655m },
                { 22, 0.64m },
                { 23, 0.626m },
                { 24, 0.612m },
                { 25, 0.6m }
            };

        public decimal Mu0 { get; } = mu0;

        public decimal Sigma0 { get; } = sigma0;

        // TODO: Show warnings on big values, suggest any errors?

        public override void Calculate()
        {
            Points = [.. Subgroups.Select(s => s.Mean)];
            var threeSigma = ACoefficients[SubgroupSize] * Sigma0;
            CenterLine = Mu0;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }
    }
}