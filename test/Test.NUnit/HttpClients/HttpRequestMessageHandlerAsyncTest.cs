using Shouldly;
using System.Diagnostics;

namespace Test.NUnit.HttpClients
{
    internal class HttpRequestMessageHandlerAsyncTest : HttpClientFixture
    {
        [Test]
        public async Task HttpRequestMessageHandler_ShouldWorkCorrectly_Async()
        {
            Debug.WriteLine($"{nameof(HttpRequestMessageHandlerAsyncTest)}: HttpRequestMessageHandler_ShouldWorkCorrectly_Async fired");

            // Act
            var result = await HttpClient.GetAsync("http://test");

            var headersDict = result.RequestMessage!.Headers
                .ToDictionary(h => h.Key, h => h.Value);

            // Assert
            headersDict.ShouldContainKey("TEST"); // Shoudly

            Assert.That(headersDict, Contains.Key("TEST")); // NUnit Assert
        }
    }
}
