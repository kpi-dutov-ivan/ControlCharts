namespace Business.ControlCharts.Range
{
    public class RChart(List<Subgroup> subgroups) : XRSChart(subgroups)
    {
        public override void Calculate(List<Subgroup> subgroups)
        {
            Values = subgroups.Select(s => s.Range).ToList();
            var rangeMean = Values.Average();
            var (D3, D4) = Coefficients[SubgroupSize];
            CenterLine = rangeMean;
            LowerControlLine = D3 * rangeMean;
            UpperControlLine = D4 * rangeMean;
        }

        private static readonly Dictionary<int, (double D3, double D4)>
            Coefficients = new()
            {
                { 2, (0, 3.267) },
                { 3, (0, 2.575) },
                { 4, (0, 2.282) },
                { 5, (0, 2.114) },
                { 6, (0, 2.004) },
                { 7, (0.076, 1.924) },
                { 8, (0.136, 1.864) },
                { 9, (0.184, 1.816) },
                { 10, (0.223, 1.777) },
                { 11, (0.256, 1.744) },
                { 12, (0.283, 1.717) },
                { 13, (0.307, 1.693) },
                { 14, (0.328, 1.672) },
                { 15, (0.347, 1.653) },
                { 16, (0.363, 1.637) },
                { 17, (0.378, 1.622) },
                { 18, (0.391, 1.609) },
                { 19, (0.404, 1.596) },
                { 20, (0.415, 1.585) },
                { 21, (0.425, 1.575) },
                { 22, (0.435, 1.567) },
                { 23, (0.443, 1.557) },
                { 24, (0.452, 1.548) },
                { 25, (0.459, 1.541) }
            };

    }
}
