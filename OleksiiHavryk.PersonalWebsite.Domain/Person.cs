namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     Class that representing person around which this app is constructed.
/// </summary>
public class Person
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;

    public Contacts Contacts { get; set; } = null!;
    public Projects? Projects { get; set; }
    public Resume? Resume { get; set; }
}