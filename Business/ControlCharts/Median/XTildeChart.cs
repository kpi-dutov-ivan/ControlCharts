using Business.ControlCharts.Range;

namespace Business.ControlCharts.Median
{
    class XTildeChart : SubgroupControlChart
    {
        private ControlChart? _rangeChart;

        public XTildeChart(List<Subgroup> subgroups) : base(subgroups)
        {
            const int maxSubgroupSize = 10;

            if (SubgroupSize > maxSubgroupSize)
            {
                throw new ArgumentOutOfRangeException(nameof(subgroups), subgroups.Count, $"Subgroup size can't be greater than {maxSubgroupSize}");
            }
        }

        public override void Calculate()
        {
            base.Calculate();
            _rangeChart ??= new RChart(Subgroups);
            var rangeAverage = _rangeChart.CenterLine;
            var xMedianAverage = Subgroups.Average(s => s.Median);
            var threeSigma = A4Coefficients[SubgroupSize] * rangeAverage;
            CenterLine = xMedianAverage;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }

        private static readonly Dictionary<int, double> A4Coefficients = new()
        {
            { 2, 1.880 },
            {3, 1.187},
            { 4, 0.796 },
            { 5, 0.691 },
            {6, 0.548},
            {7, 0.508},
            { 8, 0.433 },
            {9, 0.412},
            { 10, 0.362 }
        };
    }
}
