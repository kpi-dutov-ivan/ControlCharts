#nullable enable
using Business.ControlCharts.Range;

namespace Business.ControlCharts.Median
{
    class XTildeChart<T> : SubgroupControlChart<T> where T: IValue<T>
    {
        private IControlChart<T>? _rangeChart;

        public XTildeChart(List<ISubgroup<T>> subgroups) : base(subgroups)
        {
            const int maxSubgroupSize = 10;

            if (SubgroupSize > maxSubgroupSize)
            {
                throw new ArgumentOutOfRangeException(nameof(subgroups), subgroups.Count, $"Subgroup size can't be greater than {maxSubgroupSize}");
            }
        }

        public override void Calculate()
        {
            _rangeChart ??= new RChart<T>([.. Subgroups.Select(s => s.Range)], SubgroupSize);
            var rangeAverage = _rangeChart.CenterLine;
            var xMedianAverage = ValueHelpers<T>
                .CalculateAverage(Subgroups.Select(s => s.Median).ToList());

            var threeSigma = rangeAverage.Multiply(A4Coefficients[SubgroupSize]);
            CenterLine = xMedianAverage;
            LowerControlLine = CenterLine.Subtract(threeSigma);
            UpperControlLine = CenterLine.Add(threeSigma);
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
