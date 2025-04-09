using System.Collections.Generic;
using Business.ControlCharts.StandardDeviation;
using Xunit;

namespace Tests.StandardDeviation
{
    public class SChartPreSpecifiedTests
    {
        public static TheoryData<SChartPreSpecifiedTestCase> GetSChartPreSpecifiedValidTestData()
        {
            return
                new TheoryData<SChartPreSpecifiedTestCase>
                {
                    // SOURCE: ISO 7870-2:2013 p.28-30
                    new SChartPreSpecifiedTestCase(
                        new List<decimal>
                        {
                            0.052m, 0.022m, 0.066m, 0.023m, 0.036m, 0.066m, 0.043m, 0.038m, 0.064m, 0.049m,
                            0.019m, 0.019m, 0.031m, 0.040m, 0.058m, 0.045m, 0.063m, 0.056m, 0.056m, 0.048m,
                            0.073m, 0.041m, 0.048m, 0.065m, 0.013m
                        },
                        sigma0: 0.062m,
                        subgroupSize:5,
                        centerLine: 0.0583m,
                        upperControlLine: 0.1218m,
                        lowerControlLine: 0)
                };
        }

        [Theory]
        [MemberData(nameof(GetSChartPreSpecifiedValidTestData))]
        public void SChartPreSpecified_CalculatesProperly(SChartPreSpecifiedTestCase testCase)
        {
            var chart = new SChartPreSpecified(testCase.Points, testCase.Sigma0, testCase.SubgroupSize);
            chart.Calculate();
            ControlChartTestHelper.CheckChart(testCase, chart);
        }
    }
}