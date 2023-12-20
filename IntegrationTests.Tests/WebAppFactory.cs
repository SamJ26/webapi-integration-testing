using IntegrationTests.Api;
using IntegrationTests.Api.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace IntegrationTests.Tests;

public sealed class WebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:15.3-alpine")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // Replace original database with the one in the test container
            var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<AppDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(_postgresqlContainer.GetConnectionString()));
        });
    }

    public Task InitializeAsync()
    {
        // Uncomment for more detailed logging
        // TestcontainersSettings.Logger = LoggerFactory.Create(x => x.AddConsole()).CreateLogger("TestContainer");
        // ConsoleLogger.Instance.DebugLogLevelEnabled = true;

        return _postgresqlContainer.StartAsync();
    }

    public new Task DisposeAsync()
    {
        return _postgresqlContainer.DisposeAsync().AsTask();
    }
}