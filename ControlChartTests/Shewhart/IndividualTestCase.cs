using System.Collections.Generic;

namespace Tests
{
    public abstract class IndividualControlChartTestCase : ControlChartTestCase
    {
        public IndividualControlChartTestCase(List<decimal> points,
            decimal centerLine,
            decimal upperControlLine,
            decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
        }
    }
}