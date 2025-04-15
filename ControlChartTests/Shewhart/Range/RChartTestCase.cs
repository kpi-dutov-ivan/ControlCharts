using System.Collections.Generic;
using Business;

namespace Tests.Range
{
    public class RChartControlChartTestCase<T> : IndividualControlChartTestCase<T> where T : IValue<T>
    {
        public RChartControlChartTestCase(List<string> points,
            int subgroupTestSize,
            string centerLine,
            string upperControlLine,
            string lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            SubgroupTestSize = subgroupTestSize;
        }

        public int SubgroupTestSize { get; }
    }
}