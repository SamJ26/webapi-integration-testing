namespace IntegrationTests.Api.Endpoints;

public sealed class CreateBookEndpoint
{
    public static Task<IResult> Handle()
    {
        throw new NotImplementedException();
    }
}

public record CreateBookRequest(string Title);