using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.EntityConfigurations;
/// <summary>
///     Entity framework configuration of the Contacts entity.
/// </summary>
public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
{
    public void Configure(EntityTypeBuilder<Contacts> entity)
    {
        entity.ToTable("Contacts");
            
        entity.HasKey(c => c.Id);
            
        entity.Property(c => c.Phone).IsRequired();
        entity.Property(c => c.Telegram).IsRequired();
        entity.Property(c => c.Email).IsRequired();
        entity.Property(c => c.Github).IsRequired();
        entity.Property(c => c.Gitlab).IsRequired();
        entity.Property(c => c.LinkedIn).IsRequired();
    }
}