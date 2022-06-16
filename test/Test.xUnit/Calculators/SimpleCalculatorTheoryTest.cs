using FluentAssertions;
using System.Diagnostics;

namespace Test.xUnit.Calculators
{
    public class SimpleCalculatorTheoryTest : IClassFixture<SimpleCalculatorFixture>, IDisposable
    {
        private readonly SimpleCalculatorFixture _fixture;

        public SimpleCalculatorTheoryTest(SimpleCalculatorFixture fixture)
        {
            Debug.WriteLine("SimpleCalculatorTheoryTest: ctor fired");

            _fixture = fixture;
        }

        [Theory]
        // Arrange
        [InlineData(1, 2, 3)]
        [InlineData(-1, 1, 0)]
        [InlineData(-10, -10, -20)]
        [InlineData(11, 0, 11)]
        [InlineData(0, 0, 0)]
        [InlineData(5, -2, 3)]
        [InlineData(1, -0, 1)]
        public void SimpleCalculator_ShouldWorkCorrectly(int a, int b, int expectedResult)
        {
            // Act
            var result = _fixture.Calculator.Calculate(a, b);

            // Assert
            result.Should().Be(expectedResult); // FluentAssertions
            Assert.Equal(expectedResult, result); // xUnit Assert
        }

        public void Dispose()
        {
            Debug.WriteLine("SimpleCalculatorTheoryTest: Dispose fired");
        }
    }
}
