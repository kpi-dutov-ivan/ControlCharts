using System;
using System.Runtime.ExceptionServices;
using Business;
using Business.ControlCharts;
using Xunit;

namespace Tests
{
    public class ControlChartTestHelper<T> where T : IValue<T>
    {
        public static void CheckChart(ControlChartTestCase<T> controlChartTestCase, IControlChart<T> chart)
        {
            CheckEqualPoints(controlChartTestCase, chart);
            Assert.Equal<T>(controlChartTestCase.CenterLine, chart.CenterLine);
            Assert.Equal<T>(controlChartTestCase.UpperControlLine, chart.UpperControlLine);
            Assert.Equal<T>(controlChartTestCase.LowerControlLine, chart.LowerControlLine);
        }

        private static void CheckEqualPoints(ControlChartTestCase<T> controlChartTestCase, IControlChart<T> chart)
        {
            for (var i = 0; i < controlChartTestCase.Points.Count; i++)
                Assert.Equal(controlChartTestCase.Points[i], chart.Points[i]);
        }
    }
}