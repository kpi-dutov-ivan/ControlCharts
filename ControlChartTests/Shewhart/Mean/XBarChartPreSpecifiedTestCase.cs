using System.Collections.Generic;
using Business.ControlCharts;

namespace Tests
{
    public class XBarChartPreSpecifiedControlChartTestCase : SubgroupControlChartTestCase
    {
        public XBarChartPreSpecifiedControlChartTestCase(List<ISubgroup> subgroups, decimal mu0, decimal sigma0,
            List<decimal> points, decimal centerLine, decimal upperControlLine, decimal lowerControlLine) : base(
            subgroups, points, centerLine, upperControlLine, lowerControlLine)
        {
            Mu0 = mu0;
            Sigma0 = sigma0;
        }

        public decimal Mu0 { get; }
        public decimal Sigma0 { get; }
    }
}