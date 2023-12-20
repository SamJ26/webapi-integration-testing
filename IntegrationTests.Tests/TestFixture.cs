namespace IntegrationTests.Tests;

public abstract class TestFixture : IClassFixture<WebAppFactory>
{
    protected readonly WebAppFactory Factory;
    protected readonly HttpClient Client;

    protected TestFixture(WebAppFactory factory)
    {
        Factory = factory;
        Client = Factory.CreateClient();
    }
}