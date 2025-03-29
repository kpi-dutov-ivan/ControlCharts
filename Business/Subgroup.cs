namespace Business
{
    public class Subgroup(List<double> data)
    {
        private bool _changed = true;
        private readonly List<double> _data = [.. data];

        public IReadOnlyList<double> Data => _data.AsReadOnly();

        private double? _mean;
        private double? _standardDeviation;
        private double? _range;

        public double Mean
        {
            get
            {
                if (!_changed && _mean.HasValue) return _mean.Value;
                _mean = CalculateMean();
                _changed = false;
                return _mean.Value;
            }
        }

        public double StandardDeviation
        {
            get
            {
                if (!_changed && _standardDeviation.HasValue) return _standardDeviation.Value;
                _standardDeviation = CalculateStandardDeviation();
                _changed = false;
                return _standardDeviation.Value;
            }
        }

        public double Range
        {
            get
            {
                if (!_changed && _range.HasValue) return _range.Value;
                _range = CalculateRange();
                _changed = false;
                return _range.Value;
            }
        }

        private double CalculateMean() => _data.Average();

        private double CalculateStandardDeviation()
        {
            var mean = Mean;
            var sum = _data.Sum(value => (value - mean) * (value - mean));
            return Math.Sqrt(sum / _data.Count);
        }

        private double CalculateRange() => _data.Max() - _data.Min();

        public void UpdateData(int index, double value)
        {
            _data[index] = value;
            InvalidateCache();
        }

        public void UpdateData(List<double> newData)
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
