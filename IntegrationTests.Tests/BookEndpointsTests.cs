using System.Net;

namespace IntegrationTests.Tests;

public sealed class BookEndpointsTests : TestFixture
{
    public BookEndpointsTests(WebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAllBooksShouldReturn200()
    {
        // Arrange

        // Act
        // var response = await Client.GetAsync("books");

        // Assert
        // Assert.True(response.StatusCode == HttpStatusCode.OK);
    }
}