using System.Diagnostics;

namespace Application.Calculators
{
    public class SimpleCalculator : IDisposable
    {
        public SimpleCalculator()
        {
            Debug.WriteLine("SimpleCalculator: ctor fired");
        }

        public int Calculate(int a, int b) => a + b;

        public void Dispose()
        {
            Debug.WriteLine("SimpleCalculator: Dispose fired");
        }
    }
}
