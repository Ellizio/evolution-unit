using System.Diagnostics;

namespace Test.NUnit.HttpClients
{
    internal class HttpClientFixture
    {
        public HttpClient HttpClient { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.WriteLine($"{nameof(HttpClientFixture)}: OneTimeSetUp fired");

            HttpClient = HttpClientFixtureSetUp.HttpClient;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine($"{nameof(HttpClientFixture)}: OneTimeTearDown fired");

            HttpClient = null;
        }
    }
}
