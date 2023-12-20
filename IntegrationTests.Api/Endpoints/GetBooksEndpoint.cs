namespace IntegrationTests.Api.Endpoints;

public sealed class GetBooksEndpoint
{
    public static Task<IResult> Handle()
    {
        throw new NotImplementedException();
    }
}

public record GetBooksResponse
{
    public required List<Book> Books { get; init; }

    public record Book(
        int Id,
        string Title);
}