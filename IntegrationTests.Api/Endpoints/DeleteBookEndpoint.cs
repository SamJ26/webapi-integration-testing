using Microsoft.AspNetCore.Mvc;

namespace IntegrationTests.Api.Endpoints;

public sealed class DeleteBookEndpoint
{
    public static Task<IResult> Handle([FromRoute(Name = "id")] int bookId)
    {
        throw new NotImplementedException();
    }
}