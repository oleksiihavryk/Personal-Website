using OleksiiHavryk.PersonalWebsite.Domain;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Data;

/// <summary>
///     The repository pattern interface for the Person class.
/// </summary>
public interface IPersonRepository
{
    Task<Result<Person>> GetAsync(Guid id);
    Task<Result<Person>> CreateAsync(Person person);
    Task<Result<Person>> UpdateAsync(Person person);
    Task<Result> DeleteAsync(Guid id);
}