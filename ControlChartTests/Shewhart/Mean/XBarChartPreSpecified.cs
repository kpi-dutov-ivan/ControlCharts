using System.Collections.Generic;
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
            XBarChartPreSpecifiedControlChartTestCase controlChartTestCase)
        {
            var chart = new XBarChartPreSpecified(controlChartTestCase.Subgroups, controlChartTestCase.Mu0, controlChartTestCase.Sigma0);
            chart.Calculate();
            ControlChartTestHelper.CheckChart(controlChartTestCase, chart, 3);
        }

        public static TheoryData<XBarChartPreSpecifiedControlChartTestCase> GetXBarPreSpecifiedWithStandardDeviationTestData()
        {
            return
                new TheoryData<XBarChartPreSpecifiedControlChartTestCase>
                {
                    // SOURCE: ISO 7870-2:2013 p.28-30
                    new XBarChartPreSpecifiedControlChartTestCase(
                        new List<ISubgroup>
                        {
                            new DummySubgroup(29.816m, standardDeviation: 0.052m, size: 5),
                            new DummySubgroup(29.932m, standardDeviation: 0.022m, size: 5),
                            new DummySubgroup(29.858m, standardDeviation: 0.066m, size: 5),
                            new DummySubgroup(29.824m, standardDeviation: 0.023m, size: 5),
                            new DummySubgroup(29.888m, standardDeviation: 0.036m, size: 5),
                            new DummySubgroup(29.830m, standardDeviation: 0.066m, size: 5),
                            new DummySubgroup(29.868m, standardDeviation: 0.043m, size: 5),
                            new DummySubgroup(29.876m, standardDeviation: 0.038m, size: 5),
                            new DummySubgroup(29.910m, standardDeviation: 0.064m, size: 5),
                            new DummySubgroup(29.802m, standardDeviation: 0.049m, size: 5),
                            new DummySubgroup(29.884m, standardDeviation: 0.019m, size: 5),
                            new DummySubgroup(29.880m, standardDeviation: 0.019m, size: 5),
                            new DummySubgroup(29.916m, standardDeviation: 0.031m, size: 5),
                            new DummySubgroup(29.898m, standardDeviation: 0.040m, size: 5),
                            new DummySubgroup(29.946m, standardDeviation: 0.058m, size: 5),
                            new DummySubgroup(29.842m, standardDeviation: 0.045m, size: 5),
                            new DummySubgroup(29.824m, standardDeviation: 0.063m, size: 5),
                            new DummySubgroup(29.904m, standardDeviation: 0.056m, size: 5),
                            new DummySubgroup(29.912m, standardDeviation: 0.056m, size: 5),
                            new DummySubgroup(29.886m, standardDeviation: 0.048m, size: 5),
                            new DummySubgroup(29.908m, standardDeviation: 0.073m, size: 5),
                            new DummySubgroup(29.852m, standardDeviation: 0.041m, size: 5),
                            new DummySubgroup(29.828m, standardDeviation: 0.048m, size: 5),
                            new DummySubgroup(29.904m, standardDeviation: 0.065m, size: 5),
                            new DummySubgroup(29.902m, standardDeviation: 0.013m, size: 5)
                        },
                        29.87m,
                        0.062m,
                        new List<decimal>
                        {
                            29.816m, 29.932m, 29.858m, 29.824m, 29.888m, 29.830m, 29.868m, 29.876m, 29.910m, 29.802m,
                            29.884m, 29.880m, 29.916m, 29.898m, 29.946m, 29.842m, 29.824m, 29.904m, 29.912m, 29.886m,
                            29.908m, 29.852m, 29.828m, 29.904m, 29.902m
                        },
                        29.87m,
                        29.953m,
                        29.787m)
                };
        }
    }
}