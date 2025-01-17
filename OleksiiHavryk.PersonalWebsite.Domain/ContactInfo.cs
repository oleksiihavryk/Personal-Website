namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     All contact information with a person.
/// </summary>
public class ContactInfo
{
    public Guid Id { get; set; }
    
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Telegram { get; set; }
    public string LinkedIn { get; set; }
    public string Github { get; set; }
    public string Gitlab { get; set; }
}