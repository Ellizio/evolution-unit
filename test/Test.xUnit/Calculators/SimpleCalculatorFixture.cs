using Application.Calculators;
using System.Diagnostics;

namespace Test.xUnit.Calculators
{
    public class SimpleCalculatorFixture : IDisposable
    {
        public SimpleCalculator Calculator { get; init; }

        public SimpleCalculatorFixture()
        {
            Debug.WriteLine("SimpleCalculatorFixture: ctor fired");

            Calculator = new SimpleCalculator();
        }

        public void Dispose()
        {
            Debug.WriteLine("SimpleCalculatorFixture: Dispose fired");

            Calculator.Dispose();
        }
    }
}
