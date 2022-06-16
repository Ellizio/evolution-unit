using Application.Calculators;
using System.Diagnostics;

namespace Test.xUnit.Calculators
{
    public class SimpleCalculatorFixture : IDisposable
    {
        private readonly SimpleCalculator _calculator;

        public SimpleCalculator Calculator => _calculator;

        public SimpleCalculatorFixture()
        {
            Debug.WriteLine("SimpleCalculatorFixture: ctor fired");

            _calculator = new SimpleCalculator();
        }

        public void Dispose()
        {
            Debug.WriteLine("SimpleCalculatorFixture: Dispose fired");

            _calculator.Dispose();
        }
    }
}
