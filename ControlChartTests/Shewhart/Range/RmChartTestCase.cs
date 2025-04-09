using System.Collections.Generic;
using Business.ControlCharts.Shewhart;

namespace Tests.Range
{
    public class RmChartTestCase : IndividualControlChartTestCase, ISubgroupSized
    {
        public List<decimal> ValuePoints { get; }
        public RmChartTestCase(List<decimal> valuePoints, List<decimal> movingRangePoints, int subgroupSize, decimal centerLine, decimal upperControlLine, decimal lowerControlLine) : base(movingRangePoints, centerLine, upperControlLine, lowerControlLine)
        {
            ValuePoints = valuePoints;
            SubgroupSize = subgroupSize;
        }

        public int SubgroupSize { get; }
    }
}