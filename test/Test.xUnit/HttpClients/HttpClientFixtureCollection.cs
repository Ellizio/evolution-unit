namespace Test.xUnit.HttpClients
{
    [CollectionDefinition(nameof(HttpClientFixtureCollection))]
    public class HttpClientFixtureCollection : ICollectionFixture<HttpClientFixture>
    {
    }
}
