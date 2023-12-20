using IntegrationTests.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests;

// This class is shared for all the tests in a derived class
public abstract class TestFixture : IClassFixture<WebAppFactory>, IDisposable
{
    private readonly IServiceScope _scope;

    protected readonly HttpClient Client;
    protected readonly AppDbContext DbContext;

    protected TestFixture(WebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        Client = factory.CreateClient();
        DbContext = _scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Prepare database schema for testing
        DbContext.Database.Migrate();
        Seeds.ApplyDatabaseSeeds(DbContext);
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}