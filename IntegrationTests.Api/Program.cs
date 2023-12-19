using IntegrationTests.Api.DataAccess;
using IntegrationTests.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
        }

        var app = builder.Build();
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var groupBuilder = app.MapGroup("books");
        groupBuilder.MapGet(string.Empty, GetBooksEndpoint.Handle);
        groupBuilder.MapPost(string.Empty, CreateBookEndpoint.Handle);
        groupBuilder.MapDelete("{id:int}", DeleteBookEndpoint.Handle);

        app.Run();
    }
}