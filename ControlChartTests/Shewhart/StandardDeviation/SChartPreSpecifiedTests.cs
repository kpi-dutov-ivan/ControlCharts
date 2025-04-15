using System.Collections.Generic;
using Business;
using Business.ControlCharts.StandardDeviation;
using Xunit;

namespace Tests.StandardDeviation
{
    public class SChartPreSpecifiedTests
    {
        public static TheoryData<SChartPreSpecifiedTestCase<StatisticalValue>> GetSChartPreSpecifiedValidTestData()
        {
            return
                new TheoryData<SChartPreSpecifiedTestCase<StatisticalValue>>
                {
                    // SOURCE: ISO 7870-2:2013 p.28-30
                    new SChartPreSpecifiedTestCase<StatisticalValue>(
                        new List<string>
                        {
                            "0.052", "0.022", "0.066", "0.023", "0.036", "0.066", "0.043", "0.038", "0.064", "0.049",
                            "0.019", "0.019", "0.031", "0.040", "0.058", "0.045", "0.063", "0.056", "0.056", "0.048",
                            "0.073", "0.041", "0.048", "0.065", "0.013"
                        },
                        sigma0: "0.062",
                        subgroupSize: 5,
                        centerLine: "0.0583",
                        upperControlLine: "0.1218",
                        lowerControlLine: "0")
                };
        }

        [Theory]
        [MemberData(nameof(GetSChartPreSpecifiedValidTestData))]
        public void SChartPreSpecified_CalculatesProperly(SChartPreSpecifiedTestCase<StatisticalValue> testCase)
        {
            var chart = new SChartPreSpecified<StatisticalValue>(testCase.Points, testCase.Sigma0, testCase.SubgroupSize);
            chart.Calculate();
            ControlChartTestHelper<StatisticalValue>.CheckChart(testCase, chart);
        }
    }
}
