using FakeItEasy;
using System.Diagnostics;
using System.Net;

namespace Test.NUnit.HttpClients
{
    internal static class HttpMessageHandlerMockFactory
    {
        public static HttpMessageHandler Create()
        {
            Debug.WriteLine("HttpMessageHandlerMockFactory: Create fired");

            var mock = A.Fake<HttpMessageHandler>();

            A.CallTo(mock)
                .Where(f => f.Method.Name == "SendAsync")
                .WithReturnType<Task<HttpResponseMessage>>()
                .ReturnsLazily<HttpResponseMessage, HttpRequestMessage, CancellationToken>(
                (request, cancellationRoken) =>
                {
                    return new HttpResponseMessage
                    {
                        RequestMessage = request,
                        StatusCode = HttpStatusCode.OK
                    };
                });

            A.CallTo(mock)
                .Where(f => f.Method.Name == "Send")
                .WithReturnType<HttpResponseMessage>()
                .ReturnsLazily<HttpResponseMessage, HttpRequestMessage, CancellationToken>(
                (request, cancellationRoken) =>
                {
                    return new HttpResponseMessage
                    {
                        RequestMessage = request,
                        StatusCode = HttpStatusCode.OK
                    };
                });

            return mock;
        }
    }
}
