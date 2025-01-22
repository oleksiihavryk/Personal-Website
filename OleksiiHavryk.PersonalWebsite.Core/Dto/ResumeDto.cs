namespace OleksiiHavryk.PersonalWebsite.Core.Dto;

/// <summary>
///     DTO class for the Resume class.
/// </summary>
public class ResumeDto
{
    public string? DisplayName { get; set; }
    public string? FileName { get; set; }
    public byte[]? Data { get; set; }
}