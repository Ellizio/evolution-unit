namespace Application.HttpClients
{
    public class HttpRequestMessageHandler : DelegatingHandler
    {
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("TEST", "TEST");
            return base.Send(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("TEST", "TEST");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
