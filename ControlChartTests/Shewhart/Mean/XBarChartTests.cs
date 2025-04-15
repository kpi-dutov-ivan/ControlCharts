using System.Collections.Generic;
using System.Linq;
using Business;
using Business.ControlCharts;
using Business.ControlCharts.Mean;
using Xunit;

namespace Tests
{
    public class XBarChartTests<T> where T : IValue<T>
    {
        [Theory]
        [MemberData(nameof(GetXBarValidTestData))]
        public void XBarChartWithRange_CalculatesProperly(SubgroupControlChartTestCase<Value> controlChartTestCase)
        {
            var chart = new XBarChartCalculatedWithRange<Value>(controlChartTestCase.Subgroups.ToList());
            chart.Calculate();
            ControlChartTestHelper<Value>.CheckChart(controlChartTestCase, chart);
        }

        public static TheoryData<XBarChartTestCase<Value>> GetXBarValidTestData()
        {
            return new TheoryData<XBarChartTestCase<Value>>
            {
                // SOURCE: ISO 7870-2:2013 p.25-27
                new XBarChartTestCase<Value>(
                    new List<ISubgroup<Value>>
                    {
                        new DummySubgroup<Value>("14.0764", "0.01", 5),
                        new DummySubgroup<Value>("14.0726", "0.012", 5),
                        new DummySubgroup<Value>("14.0754", "0.008", 5),
                        new DummySubgroup<Value>("14.0770", "0.007", 5),
                        new DummySubgroup<Value>("14.0708", "0.025", 5),
                        new DummySubgroup<Value>("14.0698", "0.025", 5),
                        new DummySubgroup<Value>("14.0770", "0.009", 5),
                        new DummySubgroup<Value>("14.0744", "0.025", 5),
                        new DummySubgroup<Value>("14.0704", "0.009", 5),
                        new DummySubgroup<Value>("14.0744", "0.022", 5),
                        new DummySubgroup<Value>("14.0766", "0.009", 5),
                        new DummySubgroup<Value>("14.0568", "0.011", 5),
                        new DummySubgroup<Value>("14.0768", "0.023", 5),
                        new DummySubgroup<Value>("14.0692", "0.012", 5),
                        new DummySubgroup<Value>("14.0716", "0.019", 5),
                        new DummySubgroup<Value>("14.0748", "0.021", 5),
                        new DummySubgroup<Value>("14.0754", "0.017", 5),
                        new DummySubgroup<Value>("14.0734", "0.017", 5),
                        new DummySubgroup<Value>("14.0748", "0.035", 5),
                        new DummySubgroup<Value>("14.0754", "0.033", 5),
                        new DummySubgroup<Value>("14.0732", "0.017", 5),
                        new DummySubgroup<Value>("14.0740", "0.025", 5),
                        new DummySubgroup<Value>("14.0708", "0.017", 5),
                        new DummySubgroup<Value>("14.0760", "0.017", 5),
                        new DummySubgroup<Value>("14.0722", "0.018", 5)
                    },
                    new List<string>
                    {
                        "14.0764",
                        "14.0726",
                        "14.0754",
                        "14.0770",
                        "14.0708",
                        "14.0698",
                        "14.0770",
                        "14.0744",
                        "14.0704",
                        "14.0744",
                        "14.0766",
                        "14.0568",
                        "14.0768",
                        "14.0692",
                        "14.0716",
                        "14.0748",
                        "14.0754",
                        "14.0734",
                        "14.0748",
                        "14.0754",
                        "14.0732",
                        "14.0740",
                        "14.0708",
                        "14.0760",
                        "14.0722"
                    },
                    "14.0732",
                    "14.0834",
                    "14.0629"
                ),
                
                // SOURCE: ISO 7870-2:2013 p.27-28
                new XBarChartTestCase<Value>(
                    new List<ISubgroup<Value>>
                    {
                        new DummySubgroup<Value>("14.0764", "0.01", 5),
                        new DummySubgroup<Value>("14.0726", "0.012", 5),
                        new DummySubgroup<Value>("14.0754", "0.008", 5),
                        new DummySubgroup<Value>("14.0770", "0.007", 5),
                        new DummySubgroup<Value>("14.0708", "0.025", 5),
                        new DummySubgroup<Value>("14.0698", "0.025", 5),
                        new DummySubgroup<Value>("14.0770", "0.009", 5),
                        new DummySubgroup<Value>("14.0744", "0.025", 5),
                        new DummySubgroup<Value>("14.0704", "0.009", 5),
                        new DummySubgroup<Value>("14.0744", "0.022", 5),
                        new DummySubgroup<Value>("14.0766", "0.009", 5),
                        new DummySubgroup<Value>("14.0768", "0.023", 5),
                        new DummySubgroup<Value>("14.0692", "0.012", 5),
                        new DummySubgroup<Value>("14.0716", "0.019", 5),
                        new DummySubgroup<Value>("14.0748", "0.021", 5),
                        new DummySubgroup<Value>("14.0754", "0.017", 5),
                        new DummySubgroup<Value>("14.0734", "0.017", 5),
                        new DummySubgroup<Value>("14.0748", "0.035", 5),
                        new DummySubgroup<Value>("14.0754", "0.033", 5),
                        new DummySubgroup<Value>("14.0732", "0.017", 5),
                        new DummySubgroup<Value>("14.0740", "0.025", 5),
                        new DummySubgroup<Value>("14.0708", "0.017", 5),
                        new DummySubgroup<Value>("14.0760", "0.017", 5),
                        new DummySubgroup<Value>("14.0722", "0.018", 5)
                    },
                    new List<string>
                    {
                        "14.0764",
                        "14.0726",
                        "14.0754",
                        "14.0770",
                        "14.0708",
                        "14.0698",
                        "14.0770",
                        "14.0744",
                        "14.0704",
                        "14.0744",
                        "14.0766",
                        "14.0768",
                        "14.0692",
                        "14.0716",
                        "14.0748",
                        "14.0754",
                        "14.0734",
                        "14.0748",
                        "14.0754",
                        "14.0732",
                        "14.0740",
                        "14.0708",
                        "14.0760",
                        "14.0722"
                    },
                    "14.07385",
                    "14.0842",
                    "14.0635"
                )
            };
        }
    }
}
