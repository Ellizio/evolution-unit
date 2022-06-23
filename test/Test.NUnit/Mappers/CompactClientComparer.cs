using Application.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Test.NUnit.Mappers
{
    internal class CompactClientComparer : IEqualityComparer<CompactClient>, IDisposable
    {
        public CompactClientComparer()
        {
            Debug.WriteLine("CompactClientComparer: ctor fired");
        }

        public bool Equals(CompactClient? x, CompactClient? y)
        {
            return x.Id == y.Id
                && x.FullName == y.FullName
                && x.Inn == y.Inn
                && x.Requests == y.Requests;
        }

        public int GetHashCode([DisallowNull] CompactClient obj)
        {
            var hashCode = obj.Id ^ obj.FullName.GetHashCode() ^ obj.Inn.GetHashCode() ^ obj.Requests;
            return hashCode.GetHashCode();
        }

        public void Dispose()
        {
            Debug.WriteLine("CompactClientComparer: Dispose fired");
        }
    }
}
