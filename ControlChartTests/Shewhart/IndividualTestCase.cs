using System.Collections.Generic;

namespace Tests
{
    public class IndividualTestCase : TestCase
    {
        public IndividualTestCase(List<decimal> points,
            decimal centerLine,
            decimal upperControlLine,
            decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
        {
        }
    }
}