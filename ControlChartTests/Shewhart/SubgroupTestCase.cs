using System.Collections.Generic;
using Business.ControlCharts;

namespace Tests
{
    public abstract class SubgroupControlChartTestCase : ControlChartTestCase
    {
        protected SubgroupControlChartTestCase(List<ISubgroup> subgroups,
            List<decimal> points,
            decimal centerLine,
            decimal upperControlLine,
            decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            Subgroups = subgroups;
        }

        public List<ISubgroup> Subgroups { get; set; }
    }
}