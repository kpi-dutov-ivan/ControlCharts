using System.Collections.Generic;
using Business;
using Business.ControlCharts;

namespace Tests
{
    public class XBarChartPreSpecifiedControlChartTestCase<T> : SubgroupControlChartTestCase<T> where T : IValue<T>
    {
        public XBarChartPreSpecifiedControlChartTestCase(List<ISubgroup<T>> subgroups, string mu0, string sigma0,
            List<string> points, string centerLine, string upperControlLine, string lowerControlLine) : base(
            subgroups, points, centerLine, upperControlLine, lowerControlLine)
        {
            Mu0 = ValueFactory.CreateValue<T>(mu0);
            Sigma0 = ValueFactory.CreateValue<T>(sigma0);
        }

        public T Mu0 { get; }
        public T Sigma0 { get; }
    }
}