using Moq;
using Moq.Protected;
using System.Diagnostics;
using System.Net;

namespace Test.xUnit.HttpClients
{
    internal static class HttpMessageHandlerMockFactory
    {
        public static Mock<HttpMessageHandler> Create()
        {
            Debug.WriteLine("HttpMessageHandlerMockFactory: Create fired");

            var mock = new Mock<HttpMessageHandler>();

            mock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync<HttpRequestMessage, CancellationToken, HttpMessageHandler, HttpResponseMessage>(
                    (request, token) =>
                    {
                        return new HttpResponseMessage
                        {
                            RequestMessage = request,
                            StatusCode = HttpStatusCode.OK
                        };
                    }
                );

            mock.Protected()
                .Setup<HttpResponseMessage>("Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns<HttpRequestMessage, CancellationToken>(
                    (request, token) =>
                    {
                        return new HttpResponseMessage
                        {
                            RequestMessage = request,
                            StatusCode = HttpStatusCode.OK
                        };
                    }
                );

            return mock;
        }
    }
}
