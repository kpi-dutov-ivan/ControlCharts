using System.Collections.Generic;
using Business.ControlCharts;

namespace Tests
{
    public class XBarChartTestCase : SubgroupControlChartTestCase
    {
        public XBarChartTestCase(List<ISubgroup> subgroups, List<decimal> points, decimal centerLine, decimal upperControlLine, decimal lowerControlLine) : base(subgroups, points, centerLine, upperControlLine, lowerControlLine)
        {
        }
    }
}