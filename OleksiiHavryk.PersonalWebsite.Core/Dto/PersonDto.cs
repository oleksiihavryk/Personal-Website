namespace OleksiiHavryk.PersonalWebsite.Core.Dto;

/// <summary>
///     DTO class for the Person class.
/// </summary>
public class PersonDto
{
    public string? Name { get; set; }
    public string? About { get; set; }

    public ContactsDto? Contacts { get; set; }
    public ProjectsDto? Projects { get; set; }
    public ResumeDto? Resume { get; set; }
}