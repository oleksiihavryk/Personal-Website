using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.EntityConfigurations;
/// <summary>
///     Entity framework configuration of the Projects entity.
/// </summary>
public class ProjectsConfiguration : IEntityTypeConfiguration<Projects>
{
    public void Configure(EntityTypeBuilder<Projects> entity)
    {
        entity.ToTable("Projects");
            
        entity.HasKey(e => e.Id);
        
        entity.HasMany(p => p.ProjectsCollection)
            .WithOne()
            .HasForeignKey("ProjectsId");
    }
}