using OleksiiHavryk.PersonalWebsite.Domain;

namespace OleksiiHavryk.PersonalWebsite.Data.Extensions;

/// <summary>
///     Class for containing extension methods
///     for the Person class. 
/// </summary>
internal static class PersonExtensions
{
    public static void UpdateResume(
        this Person person, 
        Resume resume)
    {
        person.Resume = new Resume
        {
            Id = resume.Id,
            PersonId = resume.PersonId,
            FileName = resume.FileName,
            DisplayName = resume.DisplayName,
            DataString = resume.DataString
        };
    }
    public static void UpdateContacts(
        this Person person, 
        Contacts contacts)
    {
        person.Contacts = new Contacts
        {
            Id = contacts.Id,
            PersonId = contacts.PersonId,
            Email = contacts.Email,
            Phone = contacts.Phone,
            Telegram = contacts.Telegram,
            Github = contacts.Github,
            Gitlab = contacts.Gitlab,
            LinkedIn = contacts.LinkedIn,
        };
    }
    public static void UpdateProjects(
        this Person person, 
        Projects projects)
    {
        person.Projects = new Projects
        {
            Id = projects.Id,
            PersonId = projects.PersonId,
            ProjectsCollection = projects
                .ProjectsCollection
                .Select(p => new Project()
                {
                    Id = p.Id,
                    ProjectsId = p.ProjectsId,
                    Name = p.Name,
                    Description = p.Description,
                    GithubUrl = p.GithubUrl,
                    ImageUrl = p.ImageUrl,
                    SiteUrl = p.SiteUrl,
                    Show = p.Show
                })
                .ToList(),
        };
    }
}