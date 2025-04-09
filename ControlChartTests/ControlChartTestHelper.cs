using Business.ControlCharts;
using Xunit;

namespace Tests
{
    public class ControlChartTestHelper
    {
        public static void CheckChart(TestCase testCase, IControlChart chart)
        {
            // TODO: Think about customizing precision in some cases
            const int precision = 4;

            Assert.Equal(testCase.CenterLine, chart.CenterLine, precision);
            Assert.Equal(testCase.UpperControlLine, chart.UpperControlLine, precision);
            Assert.Equal(testCase.LowerControlLine, chart.LowerControlLine, precision);

            CheckEqualPoints(testCase, chart, precision);
        }

        private static void CheckEqualPoints(TestCase testCase, IControlChart chart,
            int precision)
        {
            for (var i = 0; i < testCase.Points.Count; i++)
                Assert.Equal(testCase.Points[i], chart.Points[i], precision);
        }
    }
}