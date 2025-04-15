using System.Collections.Generic;
using Business;

namespace Tests
{
    public abstract class IndividualControlChartTestCase<T> : ControlChartTestCase<T> where T : IValue<T>
    {
        public IndividualControlChartTestCase(List<string> points,
            string centerLine,
            string upperControlLine,
            string lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
        }
    }
}