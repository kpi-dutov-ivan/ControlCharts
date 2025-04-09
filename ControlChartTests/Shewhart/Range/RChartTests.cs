using System.Collections.Generic;
using Business.ControlCharts.Range;
using Xunit;

namespace Tests.Range
{
    public class RChartTests
    {
        public static TheoryData<RChartTestCase> GetRChartValidTestData()
        {
            return
                new TheoryData<RChartTestCase>
                {
                    new RChartTestCase(
                        new List<decimal>
                        {
                            0.01m, 0.012m, 0.008m, 0.007m, 0.025m, 0.025m, 0.009m, 0.025m, 0.009m, 0.022m,
                            0.009m, 0.011m, 0.023m, 0.012m, 0.019m, 0.021m, 0.017m, 0.017m, 0.035m, 0.033m,
                            0.017m, 0.025m, 0.017m, 0.017m, 0.018m
                        },
                        5,
                        0.0177m,
                        0.0375m,
                        0
                    )
                };
        }

        [Theory]
        [MemberData(nameof(GetRChartValidTestData))]
        public void RChart_CalculatesProperly(RChartTestCase testCase)
        {
            var chart = new RChart(testCase.Points, testCase.SubgroupTestSize);
            chart.Calculate();
            ControlChartTestHelper.CheckChart(testCase, chart);
        }
    }
}