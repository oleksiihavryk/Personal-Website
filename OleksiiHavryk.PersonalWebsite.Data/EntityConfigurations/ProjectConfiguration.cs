using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.EntityConfigurations;
/// <summary>
///     Entity framework configuration of the Project entity.
/// </summary>
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entity)
    {
        entity.ToTable("Project");

        entity.HasKey(e => e.Id);

        entity.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(64);
        entity.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(512);
        
        entity.Property(p => p.ImageUrl)
            .IsRequired();
        entity.Property(p => p.GithubUrl)
            .IsRequired();
        entity.Property(p => p.SiteUrl)
            .IsRequired(false);
        
        entity.Property(p => p.Show)
            .IsRequired();
    }
}
