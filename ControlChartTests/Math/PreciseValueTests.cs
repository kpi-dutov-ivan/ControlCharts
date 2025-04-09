using System;
using Business;
using Xunit;

namespace Tests.Math
{
    public class PreciseValueTests
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
            var actual = PreciseValue.DetermineDecimalPlaces(value);
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
            var actual = PreciseValue.DetermineSignificantFigures(value);
            Assert.Equal(expectedSignificantFigures, actual);
        }
        
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenRawValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PreciseValue(null));
        }
        
        // TODO: Constructor tests
        
        public static TheoryData<PreciseValue, PreciseValue, PreciseValueTestCase> AddingPreciseValues =>
            new TheoryData<PreciseValue, PreciseValue, PreciseValueTestCase>
            {
                {
                    new PreciseValue("1.2"), new PreciseValue("2.3"),
                    new PreciseValueTestCase("3.5", 3.5m, 1, 2)
                },
                {
                    new PreciseValue("2.44"), new PreciseValue("3.5666"),
                    new PreciseValueTestCase("6.01", 6.01m, 2, 3)
                },
                {
                    new PreciseValue("2.44"), new PreciseValue("3.5666e-2"),
                    new PreciseValueTestCase("2.48", 2.48m, 2, 3)
                },
                {
                    new PreciseValue("123.4567"), new PreciseValue("100.23"),
                    new PreciseValueTestCase("223.69", 223.69m, 2, 5)
                },
                {
                    new PreciseValue("123.4567"), new PreciseValue("100.23e-2"),
                    new PreciseValueTestCase("124.4590", 124.4590m, 4, 7)
                },
                {
                    new PreciseValue("0.0001"), new PreciseValue("0.0002"),
                    new PreciseValueTestCase("0.0003", 0.0003m, 4, 1)
                },
            };

        [Theory]
        [MemberData(nameof(AddingPreciseValues))]
        public void AddingPreciseValues_ProducesCorrectResult(PreciseValue a, PreciseValue b,
            PreciseValueTestCase expected)
        {
            var actual = a + b;
            TestPreciseValue(expected, actual);
        }

        private static void TestPreciseValue(PreciseValueTestCase testCase, PreciseValue preciseValue)
        {
            Assert.Equal(testCase.RawValue, preciseValue.RawValue);
            Assert.Equal(testCase.NumberValue, preciseValue.NumberValue, testCase.DecimalPlaces);
            Assert.Equal(testCase.DecimalPlaces, preciseValue.DecimalPlaces);
            Assert.Equal(testCase.SignificantDigits, preciseValue.SignificantDigits);
        }
        
        
    }
}