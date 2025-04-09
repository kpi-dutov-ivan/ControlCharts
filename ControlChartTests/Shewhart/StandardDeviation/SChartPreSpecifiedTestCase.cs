using System.Collections.Generic;
using Business.ControlCharts.Shewhart;

namespace Tests.StandardDeviation
{
    public class SChartPreSpecifiedTestCase : ControlChartTestCase, ISubgroupSized
    {
        public decimal Sigma0 { get; }
        public int SubgroupSize { get; }

        public SChartPreSpecifiedTestCase(List<decimal> points, decimal sigma0, int subgroupSize, decimal centerLine, decimal upperControlLine, decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            Sigma0 = sigma0;
            SubgroupSize = subgroupSize;
        }

    }
}