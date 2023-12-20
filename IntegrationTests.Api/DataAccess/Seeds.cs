using IntegrationTests.Api.DataAccess.Entities;

namespace IntegrationTests.Api.DataAccess;

public static class Seeds
{
    public static void ApplyDatabaseSeeds(AppDbContext dbContext)
    {
        dbContext.Books.AddRange(new BookEntity[]
        {
            new()
            {
                Title = "Refactoring"
            },
            new()
            {
                Title = "ASP.NET Core in Action"
            },
            new()
            {
                Title = "Clean Code"
            }
        });
    }
}