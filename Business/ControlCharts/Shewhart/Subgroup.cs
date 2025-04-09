#nullable enable
using Business.ControlCharts;

namespace Business
{
    public class Subgroup<T>(List<T> data) : ISubgroup<T> where T : IValue<T>
    {
        private bool _changed = true;
        private readonly List<T> _data = [.. data];

        public IReadOnlyList<T> Data => _data.AsReadOnly();

        private T? _mean;
        private T?  _standardDeviation;
        private T? _range;

        public T Mean
        {
            get
            {
                if (!_changed && _mean is not null) return _mean;
                _mean = CalculateMean();
                _changed = false;
                return _mean;
            }
        }

        public T    StandardDeviation
        {
            get
            {
                if (!_changed && _standardDeviation is not null) return _standardDeviation;
                _standardDeviation = CalculateStandardDeviation();
                _changed = false;
                return _standardDeviation;
            }
        }

        public T   Range
        {
            get
            {
                if (!_changed && _range is not null) return _range;
                _range = CalculateRange();
                _changed = false;
                return _range;
            }
        }

        public int Size { get; private set; } = data.Count;

        private T  ? _median;

        public T   Median
        {
            get
            {
                if (!_changed && _median is not null) return _median;
                _median = CalculateMedian();
                _changed = false;
                return _median;
            }
        }

        private T CalculateMean()
        {
            return ValueHelpers<T>.CalculateAverage(_data);
        }

        private T CalculateStandardDeviation()
        {
            var mean = Mean;
            var sumOfSquares = _data.Aggregate((currentSum, value) =>
                currentSum.Add(value.Subtract(mean).Multiply(value.Subtract(mean))));
            
            var variance = sumOfSquares.Divide(_data.Count - 1);
            return variance.Sqrt();
        }

        private T CalculateRange() => _data.Aggregate((maxElement, currentElement) =>
            currentElement.NumberValue > maxElement.NumberValue ? currentElement : maxElement);

        private T CalculateMedian()
        {
            var sortedData = _data.OrderBy(v => v.NumberValue).ToList();
            var length = sortedData.Count;
            return length % 2 == 1
                ? sortedData[length / 2]
                : sortedData[length / 2 - 1].Add((T)sortedData[length / 2]).Divide(2.0m);
        }

        public void UpdateData(int index, T value)
        {
            _data[index] = value;
            InvalidateCache();
        }

        public void UpdateData(List<T> newData)
        {
            _data.Clear();
            _data.AddRange(newData);
            InvalidateCache();
        }

        private void InvalidateCache()
        {
            _changed = true;
            _mean = default(T);
            _standardDeviation = default(T);
            _range = default(T);
        }
    }
}
