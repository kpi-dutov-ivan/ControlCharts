using System.Collections.Generic;
using System.Linq;
using Business;
using Business.ControlCharts.Shewhart;

namespace Tests.Range
{
    public class RmChartTestCase<T> : IndividualControlChartTestCase<T>, ISubgroupSized where T: IValue<T>
    {
        public List<T> ValuePoints { get; }
        public RmChartTestCase(List<string> valuePoints, List<string> movingRangePoints, int subgroupSize, string centerLine, string upperControlLine, string lowerControlLine) : base(movingRangePoints, centerLine, upperControlLine, lowerControlLine)
        {
            ValuePoints = valuePoints.Select(ValueFactory.CreateValue<T>).ToList();
            SubgroupSize = subgroupSize;
        }

        public int SubgroupSize { get; }
    }
}