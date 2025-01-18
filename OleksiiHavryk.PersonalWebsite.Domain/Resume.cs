namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     Resume information of the person represented as a file.
/// </summary>
public class Resume
{
    public Guid Id { get; set; }
    
    public string DisplayName { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;

    public byte[] ResumeData { get; set; } = [];
}