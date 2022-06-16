using FluentAssertions;
using System.Diagnostics;

namespace Test.xUnit.HttpClients
{
    [Collection(nameof(HttpClientFixtureCollection))]
    public class HttpRequestMessageHandlerAsyncTest : IDisposable
    {
        private readonly HttpClientFixture _fixture;

        public HttpRequestMessageHandlerAsyncTest(HttpClientFixture fixture)
        {
            Debug.WriteLine("HttpRequestMessageHandlerAsyncTest: ctor fired");

            // Arrange
            _fixture = fixture;
        }

        [Fact]
        public async Task HttpRequestMessageHandler_ShouldWorkCorrectly_Async()
        {
            // Act
            var result = await _fixture.HttpClient.GetAsync("http://test");

            // Assert
            result.RequestMessage!.Headers.Should().ContainKey("TEST"); // FluentAssetions
            Assert.Contains("TEST",
                result.RequestMessage.Headers.ToDictionary(h => h.Key, h => h.Value) as IDictionary<string, IEnumerable<string>>); // xUnit Assert
        }

        public void Dispose()
        {
            Debug.WriteLine("HttpRequestMessageHandlerAsyncTest: Dispose fired");
        }
    }
}
