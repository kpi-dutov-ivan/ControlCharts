using System.Collections.Generic;
using Business;
using Business.ControlCharts.Range;
using Xunit;

namespace Tests.Range
{
    public class RChartTests
    {
        public static TheoryData<RChartControlChartTestCase<StatisticalValue>> GetRChartValidTestData()
        {
            return
                new TheoryData<RChartControlChartTestCase<StatisticalValue>>
                {
                    // SOURCE: ISO 7870-2:2013 p.25-27
                    new RChartControlChartTestCase<StatisticalValue>(
                        new List<string>
                        {
                            "0.01", "0.012", "0.008", "0.007", "0.025", "0.025", "0.009", "0.025", "0.009", "0.022",
                            "0.009", "0.011", "0.023", "0.012", "0.019", "0.021", "0.017", "0.017", "0.035", "0.033",
                            "0.017", "0.025", "0.017", "0.017", "0.018"
                        },
                        5,
                        "0.0177",
                        "0.0375",
                        "0"
                    ),
                    
                    // SOURCE: ISO 7870-2:2013 p.27-28
                    new RChartControlChartTestCase<StatisticalValue>(
                        new List<string>()
                        {
                            "0.01", "0.012", "0.008", "0.007", "0.025", "0.025", "0.009", "0.025", "0.009", "0.022",
                            "0.009", "0.023", "0.012", "0.019", "0.021", "0.017", "0.017", "0.035", "0.033",
                            "0.017", "0.025", "0.017", "0.017", "0.018"
                        },
                        5,
                        "0.0180",
                        "0.0381",
                        "0")
                };
        }

        [Theory]
        [MemberData(nameof(GetRChartValidTestData))]
        public void RChart_CalculatesProperly(RChartControlChartTestCase<StatisticalValue> controlChartTestCase)
        {
            var chart = new RChart<StatisticalValue>(controlChartTestCase.Points, controlChartTestCase.SubgroupTestSize);
            chart.Calculate();
            ControlChartTestHelper<StatisticalValue>.CheckChart(controlChartTestCase, chart);
        }
    }
}
