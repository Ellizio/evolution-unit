using Application.HttpClients;
using System.Diagnostics;

namespace Test.NUnit.HttpClients
{
    [SetUpFixture]
    public class HttpClientFixtureSetUp
    {
        public static HttpClient HttpClient { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine($"{nameof(HttpClientFixtureSetUp)}: OneTimeSetUp fired");

            HttpClient = new HttpClient(new HttpRequestMessageHandler
            {
                InnerHandler = HttpMessageHandlerMockFactory.Create()
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine($"{nameof(HttpClientFixtureSetUp)}: OneTimeTearDown fired");

            HttpClient?.Dispose();
        }
    }
}
