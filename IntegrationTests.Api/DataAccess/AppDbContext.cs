using IntegrationTests.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Api.DataAccess;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BookEntity> Books { get; init; } = null!;
}