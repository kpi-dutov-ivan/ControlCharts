using System.Collections.Generic;
using Business;
using Business.ControlCharts;
using Business.ControlCharts.Mean;
using Xunit;

namespace Tests
{
    public class XBarChartPreSpecifiedTests
    {
        [Theory]
        [MemberData(nameof(GetXBarPreSpecifiedWithStandardDeviationTestData))]
        public void XBarChartWithStandardDeviation_WhenPreSpecified_CalculatesProperly(
            XBarChartPreSpecifiedControlChartTestCase<StatisticalValue> controlChartTestCase) 
        {
            var chart = new XBarChartPreSpecified<StatisticalValue>(controlChartTestCase.Subgroups, controlChartTestCase.Mu0, controlChartTestCase.Sigma0);
            chart.Calculate();
            ControlChartTestHelper<StatisticalValue>.CheckChart(controlChartTestCase, chart);
        }

        public static TheoryData<XBarChartPreSpecifiedControlChartTestCase<StatisticalValue>> GetXBarPreSpecifiedWithStandardDeviationTestData()
        {
            return
                new TheoryData<XBarChartPreSpecifiedControlChartTestCase<StatisticalValue>>
                {
                    // SOURCE: ISO 7870-2:2013 p.28-30
                    new XBarChartPreSpecifiedControlChartTestCase<StatisticalValue>(
                        new List<ISubgroup<StatisticalValue>>
                        {
                            new DummySubgroup<StatisticalValue>("29.816", standardDeviation: "0.052", size: 5),
                            new DummySubgroup<StatisticalValue>("29.932", standardDeviation: "0.022", size: 5),
                            new DummySubgroup<StatisticalValue>("29.858", standardDeviation: "0.066", size: 5),
                            new DummySubgroup<StatisticalValue>("29.824", standardDeviation: "0.023", size: 5),
                            new DummySubgroup<StatisticalValue>("29.888", standardDeviation: "0.036", size: 5),
                            new DummySubgroup<StatisticalValue>("29.830", standardDeviation: "0.066", size: 5),
                            new DummySubgroup<StatisticalValue>("29.868", standardDeviation: "0.043", size: 5),
                            new DummySubgroup<StatisticalValue>("29.876", standardDeviation: "0.038", size: 5),
                            new DummySubgroup<StatisticalValue>("29.910", standardDeviation: "0.064", size: 5),
                            new DummySubgroup<StatisticalValue>("29.802", standardDeviation: "0.049", size: 5),
                            new DummySubgroup<StatisticalValue>("29.884", standardDeviation: "0.019", size: 5),
                            new DummySubgroup<StatisticalValue>("29.880", standardDeviation: "0.019", size: 5),
                            new DummySubgroup<StatisticalValue>("29.916", standardDeviation: "0.031", size: 5),
                            new DummySubgroup<StatisticalValue>("29.898", standardDeviation: "0.040", size: 5),
                            new DummySubgroup<StatisticalValue>("29.946", standardDeviation: "0.058", size: 5),
                            new DummySubgroup<StatisticalValue>("29.842", standardDeviation: "0.045", size: 5),
                            new DummySubgroup<StatisticalValue>("29.824", standardDeviation: "0.063", size: 5),
                            new DummySubgroup<StatisticalValue>("29.904", standardDeviation: "0.056", size: 5),
                            new DummySubgroup<StatisticalValue>("29.912", standardDeviation: "0.056", size: 5),
                            new DummySubgroup<StatisticalValue>("29.886", standardDeviation: "0.048", size: 5),
                            new DummySubgroup<StatisticalValue>("29.908", standardDeviation: "0.073", size: 5),
                            new DummySubgroup<StatisticalValue>("29.852", standardDeviation: "0.041", size: 5),
                            new DummySubgroup<StatisticalValue>("29.828", standardDeviation: "0.048", size: 5),
                            new DummySubgroup<StatisticalValue>("29.904", standardDeviation: "0.065", size: 5),
                            new DummySubgroup<StatisticalValue>("29.902", standardDeviation: "0.013", size: 5)
                        },
                        "29.87",
                        "0.062",
                        new List<string>
                        {
                            "29.816", "29.932", "29.858", "29.824", "29.888", "29.830", "29.868", "29.876", "29.910", "29.802",
                            "29.884", "29.880", "29.916", "29.898", "29.946", "29.842", "29.824", "29.904", "29.912", "29.886",
                            "29.908", "29.852", "29.828", "29.904", "29.902"
                        },
                        "29.87",
                        "29.953",
                        "29.787")
                };
        }
    }
}
