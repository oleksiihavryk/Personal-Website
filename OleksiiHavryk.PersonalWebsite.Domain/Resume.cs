using System.ComponentModel.DataAnnotations.Schema;

namespace OleksiiHavryk.PersonalWebsite.Domain;

/// <summary>
///     Resume information of the person represented as a file.
/// </summary>
public class Resume
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }
    
    public string DisplayName { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    
    public string DataString { get; set; } = string.Empty;

    [NotMapped]
    public byte[] Data
    {
        get => Convert.FromBase64String(DataString);
        set => DataString = Convert.ToBase64String(value);
    }
}