using System.Collections.Generic;

namespace Tests.Range
{
    public class RChartTestCase : IndividualTestCase
    {
        public RChartTestCase(List<decimal> points,
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