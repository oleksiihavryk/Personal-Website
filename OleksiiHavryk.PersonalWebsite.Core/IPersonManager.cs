using OleksiiHavryk.PersonalWebsite.Core.Dto;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Core;

/// <summary>
///     Interface of the PersonManager, class that operating
///     with a person object that already exists in the system.
/// </summary>
public interface IPersonManager
{
    Task<Result<PersonDto>> GetAsync();
    Task<Result> UpdateAsync(PersonDto dto);
}