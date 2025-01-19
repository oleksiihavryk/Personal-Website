using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.EntityConfigurations;

/// <summary>
///     Entity framework configuration of the Resume entity.
/// </summary>
public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> entity)
    {
        entity.ToTable("Resume");
            
        entity.HasKey(e => e.Id);

        entity.Property(p => p.DisplayName)
            .HasMaxLength(64)
            .IsRequired();
        
        entity.Property(p => p.FileName)
            .IsRequired();
        entity.Property(p => p.DataString)
            .IsRequired();
    }
}