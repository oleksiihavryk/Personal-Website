namespace OleksiiHavryk.PersonalWebsite.Core.Dto;

public class ProjectDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public string? ImageUrl { get; set; }
    public string? GithubUrl { get; set; }
    public string? SiteUrl { get; set; }

    public bool? Show { get; set; }
}