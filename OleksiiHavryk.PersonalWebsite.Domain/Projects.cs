namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     Projects of the person.
/// </summary>
public class Projects
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public Guid PersonId { get; set; }
    
    public ICollection<Project> ProjectsCollection { get; set; } = new List<Project>();
}