using System.Collections;
using System.Diagnostics;

namespace Test.NUnit.Calculators
{
    internal static class SimpleCalculatorTestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                Debug.WriteLine($"{nameof(SimpleCalculatorTestCases)}: TestCases fired");

                yield return new TestCaseData(1, 2, 3);
                yield return new TestCaseData(-1, 1, 0);
                yield return new TestCaseData(-10, -10, -20);
            }
        }
    }
}
