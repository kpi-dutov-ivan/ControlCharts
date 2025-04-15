using System.Collections.Generic;
using Business;
using Business.ControlCharts;

namespace Tests
{
    public class XBarChartTestCase<T> : SubgroupControlChartTestCase<T> where T: IValue<T>
    {
        public XBarChartTestCase(List<ISubgroup<T>> subgroups, List<string> points, string centerLine, string upperControlLine, string lowerControlLine) : base(subgroups, points, centerLine, upperControlLine, lowerControlLine)
        {
        }
    }
}