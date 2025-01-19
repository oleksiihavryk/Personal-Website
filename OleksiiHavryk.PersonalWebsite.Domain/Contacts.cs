namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     All contact information with a person.
/// </summary>
public class Contacts
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public Guid PersonId { get; set; } = Guid.Empty;
    
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telegram { get; set; } = string.Empty;
    public string LinkedIn { get; set; } = string.Empty;
    public string Github { get; set; } = string.Empty;
    public string Gitlab { get; set; } = string.Empty;
} 