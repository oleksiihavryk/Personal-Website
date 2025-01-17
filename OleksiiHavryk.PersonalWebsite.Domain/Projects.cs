namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     Projects of the person.
/// </summary>
public class Projects
{
    public ICollection<Project> ProjectsCollection { get; set; } = new List<Project>();
}