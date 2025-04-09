using System.Collections.Generic;
using Business.ControlCharts.Range;
using Xunit;

namespace Tests.Range
{
    public class RChartTests
    {
        public static TheoryData<RChartControlChartTestCase> GetRChartValidTestData()
        {
            return
                new TheoryData<RChartControlChartTestCase>
                {
                    // SOURCE: ISO 7870-2:2013 p.25-27
                    new RChartControlChartTestCase(
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
                    ),
                    
                    // SOURCE: ISO 7870-2:2013 p.27-28
                    new RChartControlChartTestCase(
                        new List<decimal>()
                        {
                            0.01m, 0.012m, 0.008m, 0.007m, 0.025m, 0.025m, 0.009m, 0.025m, 0.009m, 0.022m,
                            0.009m, 0.023m, 0.012m, 0.019m, 0.021m, 0.017m, 0.017m, 0.035m, 0.033m,
                            0.017m, 0.025m, 0.017m, 0.017m, 0.018m
                        },
                        5,
                        0.0180m,
                        0.0381m,
                        0)
                };
        }

        [Theory]
        [MemberData(nameof(GetRChartValidTestData))]
        public void RChart_CalculatesProperly(RChartControlChartTestCase controlChartTestCase)
        {
            var chart = new RChart(controlChartTestCase.Points, controlChartTestCase.SubgroupTestSize);
            chart.Calculate();
            ControlChartTestHelper.CheckChart(controlChartTestCase, chart);
        }
    }
}