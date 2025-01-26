using OleksiiHavryk.PersonalWebsite.Core.Dto;
using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Core.Extensions;

/// <summary>
///     Class for containing extension methods
///     for the Person class. 
/// </summary>
internal static class PersonExtensions
{
    public static PersonDto ConvertToDto(this Person person)
    {
        var dto = new PersonDto()
        {
            Name = person.Name,
            About = person.About,
            Contacts = new ContactsDto()
            {
                Email = person.Contacts.Email,
                Phone = person.Contacts.Phone,
                Github = person.Contacts.Github,
                Gitlab = person.Contacts.Gitlab,
                LinkedIn = person.Contacts.LinkedIn,
                Telegram = person.Contacts.Telegram,
            }
        };

        if (person.Resume is not null)
        {
            dto.Resume = new ResumeDto()
            {
                FileName = person.Resume.FileName,
                DisplayName = person.Resume.DisplayName,
                Data = person.Resume.Data,
            };
        }

        if (person.Projects is not null)
        {
            dto.Projects = new ProjectsDto()
            {
                Projects = person.Projects
                    .ProjectsCollection
                    .Select(p => new ProjectDto()
                    {
                        Name = p.Name,
                        Description = p.Description,
                        GithubUrl = p.GithubUrl,
                        ImageUrl = p.ImageUrl,
                        SiteUrl = p.SiteUrl,
                        Show = p.Show
                    })
                    .ToList()
            };
        }
        
        return dto;
    }
    public static void ModifyContactsWith(
        this Person person, 
        ContactsDto contacts)
    {
        person.Contacts.Email = 
            contacts.Email ?? person.Contacts.Email;
        person.Contacts.Phone = 
            contacts.Phone ?? person.Contacts.Phone;
        person.Contacts.Telegram = 
            contacts.Telegram ?? person.Contacts.Telegram;
        person.Contacts.Github =
            contacts.Github ?? person.Contacts.Github;
        person.Contacts.Gitlab =
            contacts.Gitlab ?? person.Contacts.Gitlab;
        person.Contacts.LinkedIn =
            contacts.LinkedIn ?? person.Contacts.LinkedIn;
    }
    public static void ModifyProjectsWith(
        this Person person, 
        ProjectsDto projects)
    {
        if (projects.Projects is null) return;
        
        person.Projects.ProjectsCollection = 
            projects.Projects
                .Select(p => new Project()
                {
                    Name = p.Name ?? string.Empty,
                    Description = p.Description ?? string.Empty,
                    GithubUrl = p.GithubUrl ?? string.Empty,
                    ImageUrl = p.ImageUrl ?? string.Empty,
                    SiteUrl = p.SiteUrl,
                    Show = p.Show ?? false
                })
                .ToList();
    }
    public static void ModifyResumeWith(
        this Person person, 
        ResumeDto resume)
    {
        person.Resume.FileName = 
            resume.FileName ?? person.Resume.FileName;
        person.Resume.DisplayName = 
            resume.DisplayName ?? person.Resume.DisplayName;
        person.Resume.Data = 
            resume.Data ?? person.Resume.Data;
    }
}