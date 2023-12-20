using System.Net.Http.Json;
using IntegrationTests.Api.Endpoints;
using Microsoft.AspNetCore.Http;

namespace IntegrationTests.Tests;

public sealed class BookEndpointsTests : TestFixture
{
    // New instance of this class is created for each test
    public BookEndpointsTests(WebAppFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateBookTest()
    {
        // Arrange
        const string bookTitle = "Integration Testing";

        // Act
        var request = new CreateBookRequest(bookTitle);
        var response = await Client.PostAsJsonAsync("/books", request);

        // Assert
        Assert.Equal(StatusCodes.Status201Created, (int)response.StatusCode);

        var responseBody = await response
            .Content
            .ReadFromJsonAsync<CreateBookResponse>();

        var book = await DbContext.Books.FindAsync(responseBody!.Id);

        Assert.NotNull(book);
        Assert.Equal(bookTitle, book.Title);
    }

    [Fact]
    public async Task GetAllBooksTest()
    {
        // Arrange

        // Act
        var response = await Client.GetAsync("/books");

        // Assert
        Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);

        var responseBody = await response
            .Content
            .ReadFromJsonAsync<GetBooksResponse>();

        var books = responseBody!.Books;

        Assert.NotNull(books);
        Assert.NotEmpty(books);
    }
}