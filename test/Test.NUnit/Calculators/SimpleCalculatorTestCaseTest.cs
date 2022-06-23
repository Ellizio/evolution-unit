using Application.Calculators;
using Shouldly;
using System.Collections;
using System.Diagnostics;

namespace Test.NUnit.Calculators
{
    [TestFixture]
    internal class SimpleCalculatorTestCaseTest
    {
        private SimpleCalculator _simpleCalculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine($"{nameof(SimpleCalculatorTestCaseTest)}: OneTimeSetUp fired");

            _simpleCalculator = new();
        }

        [TestCaseSource(typeof(SimpleCalculatorTestCases), nameof(SimpleCalculatorTestCases.TestCases))]
        public void SimpleCalculator_ShouldWorkCorrectly_FromDataClass(int a, int b, int expectedResult)
        {
            // Act
            var result = _simpleCalculator.Calculate(a, b);

            // Assert
            result.ShouldBe(expectedResult); // Shouldly
            Assert.That(result, Is.EqualTo(expectedResult)); // NUnit Assert
        }

        [TestCaseSource(nameof(GetTestCases))]
        public void SimpleCalculator_ShouldWorkCorrectly_FromMethod(int a, int b, int expectedResult)
        {
            // Act
            var result = _simpleCalculator.Calculate(a, b);

            // Assert
            result.ShouldBe(expectedResult); // Shouldly
            Assert.That(result, Is.EqualTo(expectedResult)); // NUnit Assert
        }

        [TestCaseSource(nameof(GetTestCasesWithoutAssert))]
        public int SimpleCalculator_ShouldWorkCorrectly_WithoutAssert(int a, int b)
        {
            // Act
            return _simpleCalculator.Calculate(a, b);
        }

        private static IEnumerable GetTestCases()
        {
            Debug.WriteLine($"{nameof(SimpleCalculatorTestCaseTest)}: GetTestCases fired");

            yield return new TestCaseData(11, 0, 11);
            yield return new TestCaseData(0, 0, 0);
            yield return new TestCaseData(5, -2, 3);
        }

        private static IEnumerable GetTestCasesWithoutAssert()
        {
            Debug.WriteLine($"{nameof(SimpleCalculatorTestCaseTest)}: GetTestCasesWithoutAssert fired");

            yield return new TestCaseData(100, 222).Returns(322);
            yield return new TestCaseData(55, 55).Returns(110);
            yield return new TestCaseData(-90, -111).Returns(-201);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine($"{nameof(SimpleCalculatorTestCaseTest)}: OneTimeTearDown fired");

            _simpleCalculator.Dispose();
        }
    }
}
