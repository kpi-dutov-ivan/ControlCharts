using System.Collections.Generic;
using Business;
using Business.ControlCharts;

namespace Tests
{
    public abstract class SubgroupControlChartTestCase<T> : ControlChartTestCase<T> where T: IValue<T>
    {
        protected SubgroupControlChartTestCase(List<ISubgroup<T>> subgroups,
            List<string> points,
            string centerLine,
            string upperControlLine,
            string lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
            Subgroups = subgroups;
        }

        public List<ISubgroup<T>> Subgroups { get; set; }
    }
}