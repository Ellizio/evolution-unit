using Shouldly;
using System.Diagnostics;

namespace Test.NUnit.HttpClients
{
    internal class HttpRequestMessageHandlerSyncTest : HttpClientFixture
    {
        [Test]
        public void HttpRequestMessageHandler_ShouldWorkCorrectly_Sync()
        {
            Debug.WriteLine($"{nameof(HttpRequestMessageHandlerAsyncTest)}: HttpRequestMessageHandler_ShouldWorkCorrectly_Async fired");

            // Act
            var result = HttpClient.Send(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://test")
            });

            var headersDict = result.RequestMessage!.Headers
                .ToDictionary(h => h.Key, h => h.Value);

            // Assert
            headersDict.ShouldContainKey("TEST"); // Shoudly

            Assert.That(headersDict, Contains.Key("TEST")); // NUnit Assert
        }
    }
}
