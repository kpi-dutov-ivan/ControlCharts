using System.Collections.Generic;
using Business.ControlCharts.Individual;
using Xunit;

namespace Tests.Range
{
    public class RmChartTests
    {
        [Theory]
        [MemberData(nameof(RmChartTestCases))]
        public void RmChartTest(RmChartTestCase testCase)
        {
            var rmChart = new RMChart(testCase.ValuePoints);
            rmChart.Calculate();

            ControlChartTestHelper.CheckChart(testCase, rmChart);
        }
        
        public static TheoryData<RmChartTestCase> RmChartTestCases => new TheoryData<RmChartTestCase>
        {
            new RmChartTestCase(
                new List<decimal>
                {
                    2.9m,
                    3.2m,
                    3.6m,
                    4.3m,
                    3.8m,
                    3.5m,
                    3m,
                    3.1m,
                    3.6m,
                    3.5m,
                    3.1m,
                    3.4m,
                    3.4m,
                    3.6m,
                    3.3m,
                    3.9m,
                    3.5m,
                    3.6m,
                    3.3m,
                    3m,
                    3.4m,
                    3.8m,
                    3.5m,
                    3.2m,
                    3.5m,

                },
                new List<decimal>
                {
                    0.3m,
                    0.4m,
                    0.7m,
                    0.5m,
                    0.3m,
                    0.5m,
                    0.1m,
                    0.5m,
                    0.1m,
                    0.4m,
                    0.3m,
                    0m,
                    0.2m,
                    0.3m,
                    0.6m,
                    0.4m,
                    0.1m,
                    0.3m,
                    0.3m,
                    0.4m,
                    0.4m,
                    0.3m,
                    0.3m,
                    0.3m,
                },
                2,
                0.3333m,
                1.078m,
                0m
            ),
        };
    }
}