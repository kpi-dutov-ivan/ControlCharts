using System.Collections.Generic;
using Business;
using Business.ControlCharts.Individual;
using Xunit;

namespace Tests.Range
{
    public class RmChartTests
    {
        [Theory]
        [MemberData(nameof(RmChartTestCases))]
        public void RmChartTest(RmChartTestCase<Value> testCase)
        {
            var rmChart = new RMChart<Value>(testCase.ValuePoints);
            rmChart.Calculate();

            ControlChartTestHelper<Value>.CheckChart(testCase, rmChart);
        }
        
        public static TheoryData<RmChartTestCase<Value>> RmChartTestCases => new TheoryData<RmChartTestCase<Value>>
        {
            new RmChartTestCase<Value>(
                new List<string>
                {
                    "2.9", "3.2", "3.6", "4.3", "3.8", "3.5", "3", "3.1", "3.6", "3.5",
                    "3.1", "3.4", "3.4", "3.6", "3.3", "3.9", "3.5", "3.6", "3.3", "3",
                    "3.4", "3.8", "3.5", "3.2", "3.5"
                },
                new List<string>
                {
                    "0.3", "0.4", "0.7", "0.5", "0.3", "0.5", "0.1", "0.5", "0.1", "0.4",
                    "0.3", "0", "0.2", "0.3", "0.6", "0.4", "0.1", "0.3", "0.3", "0.4",
                    "0.4", "0.3", "0.3", "0.3"
                },
                2,
                "0.3333",
                "1.078",
                "0"
            ),
        };
    }
}
