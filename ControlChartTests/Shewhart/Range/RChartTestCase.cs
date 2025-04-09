using System.Collections.Generic;

namespace Tests.Range
{
    public class RChartControlChartTestCase : IndividualControlChartTestCase
    {
        public RChartControlChartTestCase(List<decimal> points,
            int subgroupTestSize,
            decimal centerLine,
            decimal upperControlLine,
            decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            SubgroupTestSize = subgroupTestSize;
        }

        public int SubgroupTestSize { get; }
    }
}