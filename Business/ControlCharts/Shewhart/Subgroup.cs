using Business.ControlCharts;

namespace Business
{
    public class Subgroup(List<decimal> data) : ISubgroup
    {
        private bool _changed = true;
        private readonly List<decimal> _data = [.. data];

        public IReadOnlyList<decimal> Data => _data.AsReadOnly();

        private decimal? _mean;
        private decimal? _standardDeviation;
        private decimal? _range;

        public decimal Mean
        {
            get
            {
                if (!_changed && _mean.HasValue) return _mean.Value;
                _mean = CalculateMean();
                _changed = false;
                return _mean.Value;
            }
        }

        public decimal StandardDeviation
        {
            get
            {
                if (!_changed && _standardDeviation.HasValue) return _standardDeviation.Value;
                _standardDeviation = CalculateStandardDeviation();
                _changed = false;
                return _standardDeviation.Value;
            }
        }

        public decimal Range
        {
            get
            {
                if (!_changed && _range.HasValue) return _range.Value;
                _range = CalculateRange();
                _changed = false;
                return _range.Value;
            }
        }

        public int Size { get; private set; } = data.Count;

        private decimal? _median;

        public decimal Median
        {
            get
            {
                if (!_changed && _median.HasValue) return _median.Value;
                _median = CalculateMedian();
                _changed = false;
                return _median.Value;
            }
        }

        private decimal CalculateMean() => _data.Average();

        private decimal CalculateStandardDeviation()
        {
            var mean = Mean;
            var sum = _data.Sum(value => (value - mean) * (value - mean));
            return Math.Sqrt(sum / _data.Count);
        }

        private decimal CalculateRange() => _data.Max() - _data.Min();

        private decimal CalculateMedian()
        {
            var sortedData = _data.OrderBy(v => v).ToList();
            var length = sortedData.Count;
            return length % 2 == 1
                ? sortedData[length / 2]
                : (sortedData[length / 2 - 1] + sortedData[length / 2]) / 2.0m;
        }

        public void UpdateData(int index, decimal value)
        {
            _data[index] = value;
            InvalidateCache();
        }

        public void UpdateData(List<decimal> newData)
        {
            _data.Clear();
            _data.AddRange(newData);
            InvalidateCache();
        }

        private void InvalidateCache()
        {
            _changed = true;
            _mean = null;
            _standardDeviation = null;
            _range = null;
        }
    }
}
