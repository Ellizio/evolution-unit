using Application.HttpClients;
using System.Diagnostics;

namespace Test.xUnit.HttpClients
{
    public class HttpClientFixture : IDisposable
    {
        public HttpClient HttpClient { get; init; }

        public HttpClientFixture()
        {
            Debug.WriteLine("HttpClientFixture: ctor fired");

            HttpClient = new HttpClient(new HttpRequestMessageHandler
            {
                InnerHandler = HttpMessageHandlerMockFactory.Create().Object
            });
        }

        public void Dispose()
        {
            Debug.WriteLine("HttpClientFixture: Dispose fired");

            HttpClient.Dispose();
        }
    }
}
