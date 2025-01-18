using Microsoft.EntityFrameworkCore;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data;

/// <summary>
///     Default application DbContext.
/// </summary>
public class DefaultDbContext(
    DbContextOptions<DefaultDbContext> options) 
    : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //TODO: Configure database tables and entities.
    }
}