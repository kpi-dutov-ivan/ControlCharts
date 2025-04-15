using System;
using Business;
using Xunit;

namespace Tests.Math
{
    public class StatisticalValueTests
    {
        [Theory]
        [InlineData("100.233", 3)]
        [InlineData("100.2", 1)]
        [InlineData("100.0", 1)]
        [InlineData("100", 0)]
        [InlineData("1.3e4", 0)]
        [InlineData("1.3e-4", 5)]
        
        public void DetermineDecimalPlaces_CountsProperly(string value, int expectedDecimalPlaces)
        {
            var actual = new StatisticalValue(value).DecimalPlaces;
            Assert.Equal(expectedDecimalPlaces, actual);
        }
        
        [Theory]
        [InlineData("2.8808", 5)]
        [InlineData("0.8808", 4)]
        [InlineData("0.0808", 3)]
        [InlineData("1.3e-2", 2)]
        [InlineData("1.3e-100", 2)]
        [InlineData("1.3e2", 2)]
        [InlineData("5.6000", 5)]
        [InlineData("0.0254e6", 3)]
        
        public void DetermineSignificantFigures(string value, int expectedSignificantFigures)
        {
            var actual = new StatisticalValue(value).SignificantDigits;
            Assert.Equal(expectedSignificantFigures, actual);
        }
        
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenRawValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new StatisticalValue(null));
        }
        
        // TODO: Constructor tests
        
        public static TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>> AddingPreciseValues =>
            new TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>>
            {
                {
                    new StatisticalValue("1.2"), new StatisticalValue("2.3"),
                    new PreciseValueTestCase<StatisticalValue>("3.5", 3.5m, 1, 2)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.5666"),
                    new PreciseValueTestCase<StatisticalValue>("6.01", 6.01m, 2, 3)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.5666e-2"),
                    new PreciseValueTestCase<StatisticalValue>("2.48", 2.48m, 2, 3)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23"),
                    new PreciseValueTestCase<StatisticalValue>("223.69", 223.69m, 2, 5)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23e-2"),
                    new PreciseValueTestCase<StatisticalValue>("124.4590", 124.4590m, 4, 7)
                },
                {
                    new StatisticalValue("0.0001"), new StatisticalValue("0.0002"),
                    new PreciseValueTestCase<StatisticalValue>("0.0003", 0.0003m, 4, 1)
                },
            };

        [Theory]
        [MemberData(nameof(AddingPreciseValues))]
        public void AddingPreciseValues_ProducesCorrectResult(StatisticalValue a, StatisticalValue b,
            PreciseValueTestCase<StatisticalValue> expected)
        {
            var actual = a.Add(b);
            TestPreciseValue(expected, actual);
        }
        
        
        public static TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>> SubtractingPreciseValues =>
            new TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>>
            {
                {
                    new StatisticalValue("1.2"), new StatisticalValue("2.3"),
                    new PreciseValueTestCase<StatisticalValue>("-1.1", -1.1m, 1, 2)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.5666"),
                    new PreciseValueTestCase<StatisticalValue>("-1.13", -1.13m, 2, 3)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.5666e-2"),
                    new PreciseValueTestCase<StatisticalValue>("2.40", 2.40m, 2, 3)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23"),
                    new PreciseValueTestCase<StatisticalValue>("23.23", 23.23m, 2, 4)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23e-2"),
                    new PreciseValueTestCase<StatisticalValue>("122.4544", 122.4544m, 4, 7)
                },
                {
                    new StatisticalValue("0.0001"), new StatisticalValue("0.0002"),
                    new PreciseValueTestCase<StatisticalValue>("-0.0001", -0.0001m, 4, 1)
                },
            };
        
        [Theory]
        [MemberData(nameof(SubtractingPreciseValues))]
        public void SubtractingPreciseValues_ProducesCorrectResult(StatisticalValue a, StatisticalValue b,
            PreciseValueTestCase<StatisticalValue> expected)
        {
            var actual = a.Subtract(b);
            TestPreciseValue(expected, actual);
        }

        private static void TestPreciseValue(PreciseValueTestCase<StatisticalValue> testCase, StatisticalValue statisticalValue)
        {
            Assert.Equal(testCase.RawValue, statisticalValue.RawValue);
            Assert.Equal(testCase.NumberValue, statisticalValue.NumberValue, testCase.DecimalPlaces);
            Assert.Equal(testCase.DecimalPlaces, statisticalValue.DecimalPlaces);
            Assert.Equal(testCase.SignificantDigits, statisticalValue.SignificantDigits);
        }
        
        
        public static TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>> MultiplyingPreciseValues =>
            new TheoryData<StatisticalValue, StatisticalValue, PreciseValueTestCase<StatisticalValue>>
            {
                {
                    new StatisticalValue("1.2"), new StatisticalValue("2.3"),
                    new PreciseValueTestCase<StatisticalValue>("2.8", 2.8m, 1, 2)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.506"),
                    new PreciseValueTestCase<StatisticalValue>("8.55", 8.55m, 2, 3)
                },
                {
                    new StatisticalValue("2.44"), new StatisticalValue("3.5666e-2"),
                    new PreciseValueTestCase<StatisticalValue>("0.0870", 0.0870m, 3, 3)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23"),
                    new PreciseValueTestCase<StatisticalValue>("12374", 12374m, 0, 5)
                },
                {
                    new StatisticalValue("123.4567"), new StatisticalValue("100.23e-2"),
                    new PreciseValueTestCase<StatisticalValue>("123.74", 123.74m, 2, 5)
                }
            };
        
        [Theory]
        [MemberData(nameof(MultiplyingPreciseValues))]
        public void MultiplyingPreciseValues_ProducesCorrectResult(StatisticalValue a, StatisticalValue b,
            PreciseValueTestCase<StatisticalValue> expected)
        {
            var actual = a.Multiply(b);
            TestPreciseValue(expected, actual);
        }
        
    }
}