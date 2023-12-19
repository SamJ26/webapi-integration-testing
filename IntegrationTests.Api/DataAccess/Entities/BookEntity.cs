namespace IntegrationTests.Api.DataAccess.Entities;

public sealed class BookEntity : EntityBase
{
    public required string Title { get; init; }
}