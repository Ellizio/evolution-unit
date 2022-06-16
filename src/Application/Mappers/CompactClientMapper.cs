using Application.Models;
using System.Diagnostics;

namespace Application.Mappers
{
    public class CompactClientMapper : IDisposable
    {
        public CompactClientMapper()
        {
            Debug.WriteLine("CompactClientMapper: ctor fired");
        }

        public CompactClient Map(Client client)
        {
            return new CompactClient
            {
                Id = client.Id,
                FullName = $"{client.FirstName} {client.LastName}",
                Inn = client.Inn,
                Requests = client.Requests?.Count(r => r.Id > 0) ?? 0
            };
        }

        public void Dispose()
        {
            Debug.WriteLine("CompactClientMapper: Dispose fired");
        }
    }
}
