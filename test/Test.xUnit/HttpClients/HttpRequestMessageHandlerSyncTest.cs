using FluentAssertions;
using System.Diagnostics;

namespace Test.xUnit.HttpClients
{
    [Collection(nameof(HttpClientFixtureCollection))]
    public class HttpRequestMessageHandlerSyncTest : IDisposable
    {
        private readonly HttpClientFixture _fixture;

        public HttpRequestMessageHandlerSyncTest(HttpClientFixture fixture)
        {
            Debug.WriteLine("HttpRequestMessageHandlerSyncTest: ctor fired");

            // Arrange
            _fixture = fixture;
        }

        [Fact]
        public void HttpRequestMessageHandler_ShouldWorkCorrectly_Sync()
        {
            // Act
            var result = _fixture.HttpClient.Send(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://test")
            });

            // Assert
            result.RequestMessage!.Headers.Should().ContainKey("TEST"); // FluentAssetions
            Assert.Contains("TEST",
                result.RequestMessage.Headers.ToDictionary(h => h.Key, h => h.Value) as IDictionary<string, IEnumerable<string>>); // xUnit Assert
        }

        public void Dispose()
        {
            Debug.WriteLine("HttpRequestMessageHandlerSyncTest: Dispose fired");
        }
    }
}
