using Business.ControlCharts.Range;

namespace Business.ControlCharts.Median
{
    class XTildeChart : SubgroupControlChart
    {
        private IControlChart? _rangeChart;

        public XTildeChart(List<ISubgroup> subgroups) : base(subgroups)
        {
            const int maxSubgroupSize = 10;

            if (SubgroupSize > maxSubgroupSize)
            {
                throw new ArgumentOutOfRangeException(nameof(subgroups), subgroups.Count, $"Subgroup size can't be greater than {maxSubgroupSize}");
            }
        }

        public override void Calculate()
        {
            _rangeChart ??= new RChart([.. Subgroups.Select(s => s.Range)], SubgroupSize);
            var rangeAverage = _rangeChart.CenterLine;
            var xMedianAverage = Subgroups.Average(s => s.Median);
            var threeSigma = A4Coefficients[SubgroupSize] * rangeAverage;
            CenterLine = xMedianAverage;
            LowerControlLine = CenterLine - threeSigma;
            UpperControlLine = CenterLine + threeSigma;
        }

        private static readonly Dictionary<int, decimal> A4Coefficients = new()
        {
            { 2, 1.880m },
            {3, 1.187m },
            { 4, 0.796m },
            { 5, 0.691m },
            {6, 0.548m },
            {7, 0.508m },
            { 8, 0.433m },
            {9, 0.412m },
            { 10, 0.362m }
        };
    }
}
