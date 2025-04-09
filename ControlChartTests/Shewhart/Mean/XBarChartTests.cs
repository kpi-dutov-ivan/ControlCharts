using System.Collections.Generic;
using System.Linq;
using Business.ControlCharts;
using Business.ControlCharts.Mean;
using Xunit;

namespace Tests
{
    public class XBarChartTests
    {
        [Theory]
        [MemberData(nameof(GetXBarValidTestData))]
        public void XBarChartWithRange_CalculatesProperly(SubgroupControlChartTestCase controlChartTestCase)
        {
            var chart = new XBarChartCalculatedWithRange(controlChartTestCase.Subgroups.ToList());
            chart.Calculate();
            ControlChartTestHelper.CheckChart(controlChartTestCase, chart);
        }

        public static TheoryData<SubgroupControlChartTestCase> GetXBarValidTestData()
        {
            return new TheoryData<SubgroupControlChartTestCase>
            {
                // SOURCE: ISO 7870-2:2013 p.25-27
                new SubgroupControlChartTestCase(
                    new List<ISubgroup>
                    {
                        new DummySubgroup(14.0764m, 0.01m, 5),
                        new DummySubgroup(14.0726m, 0.012m, 5),
                        new DummySubgroup(14.0754m, 0.008m, 5),
                        new DummySubgroup(14.0770m, 0.007m, 5),
                        new DummySubgroup(14.0708m, 0.025m, 5),
                        new DummySubgroup(14.0698m, 0.025m, 5),
                        new DummySubgroup(14.0770m, 0.009m, 5),
                        new DummySubgroup(14.0744m, 0.025m, 5),
                        new DummySubgroup(14.0704m, 0.009m, 5),
                        new DummySubgroup(14.0744m, 0.022m, 5),
                        new DummySubgroup(14.0766m, 0.009m, 5),
                        new DummySubgroup(14.0568m, 0.011m, 5),
                        new DummySubgroup(14.0768m, 0.023m, 5),
                        new DummySubgroup(14.0692m, 0.012m, 5),
                        new DummySubgroup(14.0716m, 0.019m, 5),
                        new DummySubgroup(14.0748m, 0.021m, 5),
                        new DummySubgroup(14.0754m, 0.017m, 5),
                        new DummySubgroup(14.0734m, 0.017m, 5),
                        new DummySubgroup(14.0748m, 0.035m, 5),
                        new DummySubgroup(14.0754m, 0.033m, 5),
                        new DummySubgroup(14.0732m, 0.017m, 5),
                        new DummySubgroup(14.0740m, 0.025m, 5),
                        new DummySubgroup(14.0708m, 0.017m, 5),
                        new DummySubgroup(14.0760m, 0.017m, 5),
                        new DummySubgroup(14.0722m, 0.018m, 5)
                    },
                    new List<decimal>
                    {
                        14.0764m,
                        14.0726m,
                        14.0754m,
                        14.0770m,
                        14.0708m,
                        14.0698m,
                        14.0770m,
                        14.0744m,
                        14.0704m,
                        14.0744m,
                        14.0766m,
                        14.0568m,
                        14.0768m,
                        14.0692m,
                        14.0716m,
                        14.0748m,
                        14.0754m,
                        14.0734m,
                        14.0748m,
                        14.0754m,
                        14.0732m,
                        14.0740m,
                        14.0708m,
                        14.0760m,
                        14.0722m
                    },
                    14.0732m,
                    14.0834m,
                    14.0629m
                ),
                
                // SOURCE: ISO 7870-2:2013 p.27-28
                new SubgroupControlChartTestCase(
                    new List<ISubgroup>
                    {
                        new DummySubgroup(14.0764m, 0.01m, 5),
                        new DummySubgroup(14.0726m, 0.012m, 5),
                        new DummySubgroup(14.0754m, 0.008m, 5),
                        new DummySubgroup(14.0770m, 0.007m, 5),
                        new DummySubgroup(14.0708m, 0.025m, 5),
                        new DummySubgroup(14.0698m, 0.025m, 5),
                        new DummySubgroup(14.0770m, 0.009m, 5),
                        new DummySubgroup(14.0744m, 0.025m, 5),
                        new DummySubgroup(14.0704m, 0.009m, 5),
                        new DummySubgroup(14.0744m, 0.022m, 5),
                        new DummySubgroup(14.0766m, 0.009m, 5),
                        new DummySubgroup(14.0768m, 0.023m, 5),
                        new DummySubgroup(14.0692m, 0.012m, 5),
                        new DummySubgroup(14.0716m, 0.019m, 5),
                        new DummySubgroup(14.0748m, 0.021m, 5),
                        new DummySubgroup(14.0754m, 0.017m, 5),
                        new DummySubgroup(14.0734m, 0.017m, 5),
                        new DummySubgroup(14.0748m, 0.035m, 5),
                        new DummySubgroup(14.0754m, 0.033m, 5),
                        new DummySubgroup(14.0732m, 0.017m, 5),
                        new DummySubgroup(14.0740m, 0.025m, 5),
                        new DummySubgroup(14.0708m, 0.017m, 5),
                        new DummySubgroup(14.0760m, 0.017m, 5),
                        new DummySubgroup(14.0722m, 0.018m, 5)
                    },
                    new List<decimal>
                    {
                        14.0764m,
                        14.0726m,
                        14.0754m,
                        14.0770m,
                        14.0708m,
                        14.0698m,
                        14.0770m,
                        14.0744m,
                        14.0704m,
                        14.0744m,
                        14.0766m,
                        14.0768m,
                        14.0692m,
                        14.0716m,
                        14.0748m,
                        14.0754m,
                        14.0734m,
                        14.0748m,
                        14.0754m,
                        14.0732m,
                        14.0740m,
                        14.0708m,
                        14.0760m,
                        14.0722m
                    },
                    14.07385m,
                    14.0842m,
                    14.0635m
                )
            };
        }
    }
}