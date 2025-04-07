using System;
using System.Collections.Generic;
using System.Linq;
using Business.ControlCharts;
using Business.ControlCharts.Mean;
using Business.ControlCharts.Range;
using Xunit;

namespace Tests
{
    public class ControlChartTests
    {

        public class TestCase : IControlChart
        {
            public TestCase(List<decimal> points, decimal centerLine, decimal upperControlLine, decimal lowerControlLine)
            {
                CenterLine = centerLine;
                UpperControlLine = upperControlLine;
                LowerControlLine = lowerControlLine;
                Points = points;
            }

            public decimal CenterLine { get; set; }
            public decimal UpperControlLine { get; set; }
            public decimal LowerControlLine { get; set; }
            public List<decimal> Points { get; set; }

            public void Calculate()
            {
                throw new NotImplementedException();
            }

        }

        public class SubgroupTestCase : TestCase
        {
            public SubgroupTestCase(List<ISubgroup> subgroups,
                List<decimal> points,
                decimal centerLine,
                decimal upperControlLine,
                decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
            {
                Subgroups = subgroups;
            }

            public List<ISubgroup> Subgroups { get; set; }
        }

        public class XSTestCase : SubgroupTestCase
        {
            public XSTestCase(List<ISubgroup> subgroups, decimal mu0, decimal sigma0, List<decimal> points, decimal centerLine, decimal upperControlLine, decimal lowerControlLine) : base(subgroups, points, centerLine, upperControlLine, lowerControlLine)
            {
                Mu0 = mu0;
                Sigma0 = sigma0;
            }

            public decimal Mu0 { get; }
            public decimal Sigma0 { get; }
        }

        public class IndividualTestCase : TestCase
        {
            public IndividualTestCase(List<decimal> points,
                decimal centerLine,
                decimal upperControlLine,
                decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
            {
            }
        }

        public class RChartTestCase : IndividualTestCase
        {
            public RChartTestCase(List<decimal> points,
                int subgroupTestSize,
                decimal centerLine,
                decimal upperControlLine,
                decimal lowerControlLine) : base(points, centerLine, upperControlLine, lowerControlLine)
            {
                SubgroupTestSize = subgroupTestSize;
            }

            public int SubgroupTestSize { get; }
        }

        private class DummySubgroup : ISubgroup
        {
            public decimal Mean { get; set; }
            public decimal Median { get; set; }
            public decimal StandardDeviation { get; set; }
            public decimal Range { get; set; }
            public int Size { get; private set; }

            public DummySubgroup(decimal mean = 0.0m, decimal range = 0.0m, int size = 0, decimal standardDeviation = 0, decimal median = 0.0m){
                Mean = mean;
                Range = range;
                Size = size;
                StandardDeviation = standardDeviation;
                Median = median;
            }
        }

        public static TheoryData<SubgroupTestCase> GetXBarValidTestData()
        {
            return new TheoryData<SubgroupTestCase>
            {
                new SubgroupTestCase(
                    new List<ISubgroup>(){
                        new DummySubgroup(mean: 14.0764m, range: 0.01m, size: 5),
                        new DummySubgroup(mean: 14.0726m, range: 0.012m, size: 5),
                        new DummySubgroup(mean: 14.0754m, range: 0.008m, size: 5),
                        new DummySubgroup(mean: 14.0770m, range: 0.007m, size: 5),
                        new DummySubgroup(mean: 14.0708m, range: 0.025m, size: 5),
                        new DummySubgroup(mean: 14.0698m, range: 0.025m, size: 5),
                        new DummySubgroup(mean: 14.0770m, range: 0.009m, size: 5),
                        new DummySubgroup(mean: 14.0744m, range: 0.025m, size: 5),
                        new DummySubgroup(mean: 14.0704m, range: 0.009m, size: 5),
                        new DummySubgroup(mean: 14.0744m, range: 0.022m, size: 5),
                        new DummySubgroup(mean: 14.0766m, range: 0.009m, size: 5),
                        new DummySubgroup(mean: 14.0568m, range: 0.011m, size: 5),
                        new DummySubgroup(mean: 14.0768m, range: 0.023m, size: 5),
                        new DummySubgroup(mean: 14.0692m, range: 0.012m, size: 5),
                        new DummySubgroup(mean: 14.0716m, range: 0.019m, size: 5),
                        new DummySubgroup(mean: 14.0748m, range: 0.021m, size: 5),
                        new DummySubgroup(mean: 14.0754m, range: 0.017m, size: 5),
                        new DummySubgroup(mean: 14.0734m, range: 0.017m, size: 5),
                        new DummySubgroup(mean: 14.0748m, range: 0.035m, size: 5),
                        new DummySubgroup(mean: 14.0754m, range: 0.033m, size: 5),
                        new DummySubgroup(mean: 14.0732m, range: 0.017m, size: 5),
                        new DummySubgroup(mean: 14.0740m, range: 0.025m, size: 5),
                        new DummySubgroup(mean: 14.0708m, range: 0.017m, size: 5),
                        new DummySubgroup(mean: 14.0760m, range: 0.017m, size: 5),
                        new DummySubgroup(mean: 14.0722m, range: 0.018m, size: 5)
                    },
                    new List<decimal>() {
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
                )
            };
        }

        public static TheoryData<RChartTestCase> GetRChartValidTestData()
        {
            return
            new TheoryData<RChartTestCase>() {
                new RChartTestCase(
                    new List<decimal>() {
                        0.01m, 0.012m, 0.008m, 0.007m, 0.025m, 0.025m, 0.009m, 0.025m, 0.009m, 0.022m,
                        0.009m, 0.011m, 0.023m, 0.012m, 0.019m, 0.021m, 0.017m, 0.017m, 0.035m, 0.033m,
                        0.017m, 0.025m, 0.017m, 0.017m, 0.018m
                    },
                    5,
                    0.0177m,
                    0.0375m,
                    0
                )
            };
        }

        public static TheoryData<XSTestCase> GetXSValidTestData()
        {
            return
                new TheoryData<XSTestCase>()
                {
                    new XSTestCase(
                        new List<ISubgroup>()
                        {
                            new DummySubgroup(mean: 29.816m, standardDeviation: 0.052m, size: 5),
                            new DummySubgroup(mean: 29.932m, standardDeviation: 0.022m, size: 5),
                            new DummySubgroup(mean: 29.858m, standardDeviation: 0.066m, size: 5),
                            new DummySubgroup(mean: 29.824m, standardDeviation: 0.023m, size: 5),
                            new DummySubgroup(mean: 29.888m, standardDeviation: 0.036m, size: 5),
                            new DummySubgroup(mean: 29.830m, standardDeviation: 0.066m, size: 5),
                            new DummySubgroup(mean: 29.868m, standardDeviation: 0.043m, size: 5),
                            new DummySubgroup(mean: 29.876m, standardDeviation: 0.038m, size: 5),
                            new DummySubgroup(mean: 29.910m, standardDeviation: 0.064m, size: 5),
                            new DummySubgroup(mean: 29.802m, standardDeviation: 0.049m, size: 5),
                            new DummySubgroup(mean: 29.884m, standardDeviation: 0.019m, size: 5),
                            new DummySubgroup(mean: 29.880m, standardDeviation: 0.019m, size: 5),
                            new DummySubgroup(mean: 29.916m, standardDeviation: 0.031m, size: 5),
                            new DummySubgroup(mean: 29.898m, standardDeviation: 0.040m, size: 5),
                            new DummySubgroup(mean: 29.946m, standardDeviation: 0.058m, size: 5),
                            new DummySubgroup(mean: 29.842m, standardDeviation: 0.045m, size: 5),
                            new DummySubgroup(mean: 29.824m, standardDeviation: 0.063m, size: 5),
                            new DummySubgroup(mean: 29.904m, standardDeviation: 0.056m, size: 5),
                            new DummySubgroup(mean: 29.912m, standardDeviation: 0.056m, size: 5),
                            new DummySubgroup(mean: 29.886m, standardDeviation: 0.048m, size: 5),
                            new DummySubgroup(mean: 29.908m, standardDeviation: 0.073m, size: 5),
                            new DummySubgroup(mean: 29.852m, standardDeviation: 0.041m, size: 5),
                            new DummySubgroup(mean: 29.828m, standardDeviation: 0.048m, size: 5),
                            new DummySubgroup(mean: 29.904m, standardDeviation: 0.065m, size: 5),
                            new DummySubgroup(mean: 29.902m, standardDeviation: 0.013m, size: 5)
                        },

                        29.87m,
                        0.062m,
                        new List<decimal>()
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

        [Theory]
        [MemberData(nameof(GetXBarValidTestData))]
        public void XBarChartWithRange_CalculatesProperly(SubgroupTestCase testCase)
        {
            var chart = new XBarChartCalculatedWithRange(testCase.Subgroups.ToList());
            chart.Calculate();
            CheckChart(testCase, chart);
        }

        [Theory]
        [MemberData(nameof(GetRChartValidTestData))]
        public void RChart_CalculatesProperly(RChartTestCase testCase)
        {
            var chart = new RChart(testCase.Points, testCase.SubgroupTestSize);
            chart.Calculate();
            CheckChart(testCase, chart);
        }

        [Theory]
        [MemberData(nameof(GetXSValidTestData))]

        public void XBarChartWithStandardDeviation_WhenPreSpecified_CalculatesProperly(XSTestCase testCase)
        {
            var chart = new XBarChartPreSpecified(testCase.Subgroups, testCase.Mu0, testCase.Sigma0);
            chart.Calculate();
            CheckChart(testCase, chart);
        }

        private static void CheckChart(TestCase testCase, IControlChart chart)
        {
            // TODO: Think about customizing precision in some cases
            var precision = 4;

            Assert.Equal(testCase.CenterLine, chart.CenterLine, precision);
            Assert.Equal(testCase.UpperControlLine, chart.UpperControlLine, precision);
            Assert.Equal(testCase.LowerControlLine, chart.LowerControlLine, precision);

            CheckEqualPoints(testCase, chart, precision);
        }

        private static void CheckEqualPoints(TestCase testCase, IControlChart chart,
            int precision)
        {
            for (var i = 0; i < testCase.Points.Count; i++)
            {
                Assert.Equal(testCase.Points[i], chart.Points[i], precision);
            }
        }
    }
}
