namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     The persons project.
/// </summary>
public class Project
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public Guid PersonId { get; set; } = Guid.Empty;

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string ImageUrl { get; set; } = string.Empty;
    public string? GithubUrl { get; set; }
    public string? SiteUrl { get; set; }

    public bool Show { get; set; } = false;
}