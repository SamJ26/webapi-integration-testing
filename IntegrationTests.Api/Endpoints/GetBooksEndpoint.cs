using IntegrationTests.Api.DataAccess;
using IntegrationTests.Api.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Api.Endpoints;

public sealed class GetBooksEndpoint
{
    public static async Task<IResult> Handle([FromServices] AppDbContext dbContext)
    {
        var books = await dbContext
            .Books
            .ToListAsync();

        var response = MapToResponse(books);

        return Results.Ok(response);
    }

    private static GetBooksResponse MapToResponse(IEnumerable<BookEntity> books)
    {
        return new GetBooksResponse()
        {
            Books = books
                .Select(x => new GetBooksResponse.Book(x.Id, x.Title))
                .ToList()
        };
    }
}

public record GetBooksResponse
{
    public required List<Book> Books { get; init; }

    public record Book(
        int Id,
        string Title);
}