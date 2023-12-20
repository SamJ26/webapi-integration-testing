using IntegrationTests.Api.DataAccess;
using IntegrationTests.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTests.Api.Endpoints;

public sealed class CreateBookEndpoint
{
    public static async Task<IResult> Handle(
        [FromBody] CreateBookRequest req,
        [FromServices] AppDbContext dbContext)
    {
        var book = new BookEntity()
        {
            Title = req.Title
        };

        dbContext.Add(book);
        await dbContext.SaveChangesAsync();

        return Results.Created($"/books/{book.Id}", new CreateBookResponse(book.Id));
    }
}

public record CreateBookRequest(string Title);

public record CreateBookResponse(int Id);