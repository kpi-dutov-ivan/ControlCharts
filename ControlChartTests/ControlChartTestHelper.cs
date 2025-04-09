using System;
using Business.ControlCharts;
using Xunit;

namespace Tests
{
    public class ControlChartTestHelper
    {
        public static void CheckChart(ControlChartTestCase controlChartTestCase, IControlChart chart, int precision = 4)
        {
            if (precision <= 0)
                throw new InvalidOperationException("Cannot run test with non-positive precision");
            
            CheckEqualPoints(controlChartTestCase, chart, precision);
            Assert.Equal(controlChartTestCase.CenterLine, chart.CenterLine, precision);
            Assert.Equal(controlChartTestCase.UpperControlLine, chart.UpperControlLine, precision);
            Assert.Equal(controlChartTestCase.LowerControlLine, chart.LowerControlLine, precision);

        }

        private static void CheckEqualPoints(ControlChartTestCase controlChartTestCase, IControlChart chart,
            int precision)
        {
            for (var i = 0; i < controlChartTestCase.Points.Count; i++)
                Assert.Equal(controlChartTestCase.Points[i], chart.Points[i], precision);
        }
    }
}