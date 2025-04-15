using System.Collections.Generic;
using Business;
using Business.ControlCharts.Shewhart;

namespace Tests.StandardDeviation
{
    public class SChartPreSpecifiedTestCase<T> : ControlChartTestCase<T>, ISubgroupSized where T : IValue<T>
    {
        public T Sigma0 { get; }
        public int SubgroupSize { get; }

        public SChartPreSpecifiedTestCase(List<string> points, string sigma0, int subgroupSize, string centerLine, string upperControlLine, string lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            Sigma0 = ValueFactory.CreateValue<T>(sigma0);
            SubgroupSize = subgroupSize;
        }

    }
}