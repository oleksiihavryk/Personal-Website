using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.EntityConfigurations;
/// <summary>
///     Entity framework configuration of the Person entity.
/// </summary>
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> entity)
    {
        entity.ToTable("Person");
            
        entity.HasKey(e => e.Id);
            
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(64);
        entity.Property(e => e.About)
            .IsRequired()
            .HasMaxLength(512);

        entity.HasOne<Projects>(p => p.Projects)
            .WithOne()
            .HasForeignKey<Projects>(p => p.PersonId);
        entity.HasOne<Contacts>(p => p.Contacts)
            .WithOne()
            .HasForeignKey<Contacts>(c => c.PersonId);
        entity.HasOne<Resume>(p => p.Resume)
            .WithOne()
            .HasForeignKey<Resume>(r => r.PersonId);
    }
}