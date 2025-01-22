using Microsoft.Extensions.Logging;
using OleksiiHavryk.PersonalWebsite.Core.Constants;
using OleksiiHavryk.PersonalWebsite.Core.Dto;
using OleksiiHavryk.PersonalWebsite.Core.Extensions;
using OleksiiHavryk.PersonalWebsite.Data;
using OleksiiHavryk.PersonalWebsite.Domain;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Core;

/// <summary>
///     Core feature of the application.
///     This class operating with a person object.
/// </summary>
public class PersonManager : IPersonManager
{
    private readonly ILogger<PersonManager> _logger;
    private readonly IPersonRepository _personRepository;

    private Guid Identifier { get; } = 
        Guid.Parse(PersonConstants.DefaultIdentifier);

    public PersonManager(
        ILogger<PersonManager> logger, 
        IPersonRepository personRepository)
    {
        _logger = logger;
        _personRepository = personRepository;
    }

    public async Task<Result<PersonDto>> GetAsync()
    {
        var operationResult = await _personRepository.GetAsync(Identifier);

        if (operationResult.IsSuccess())
        {
            var dto = operationResult.Data.ConvertToDto();
            
            _logger.LogInformation(operationResult.Message);
            
            return Result.Success(dto)
                .WithMessage("Person successfully retrieved.");
        }
        
        _logger.LogError(
            $"Person has not been retrieved from database. " +
            $"Reason: {operationResult.Message}");
        
        return Result.Failure<PersonDto>()
            .WithMessage(operationResult.Message);
    }
    public async Task<Result> UpdateAsync(PersonDto dto)
    {
        Result<Person> getPersonOperationResult = 
            await _personRepository.GetAsync(Identifier);

        if (getPersonOperationResult.IsFailure())
        {
            _logger.LogError(
                $"Person has not been retrieved from database. " +
                $"Reason: {getPersonOperationResult.Message}");
            
            return Result.Failure<PersonDto>()
                .WithMessage(getPersonOperationResult.Message);
        }
        
        _logger.LogInformation(getPersonOperationResult.Message);

        Person person = getPersonOperationResult.Data;
        
        person.Name = dto.Name ?? person.Name;
        person.About = dto.About ?? person.About;
        
        if (dto.Contacts is not null)
            person.ModifyContactsWith(dto.Contacts);
        
        if (dto.Projects is not null)
            person.ModifyProjectsWith(dto.Projects);
        
        if (dto.Resume is not null)
            person.ModifyResumeWith(dto.Resume);
        
        Result<Person> operationResult = 
            await _personRepository.UpdateAsync(person);
        
        if (operationResult.IsSuccess())
        {
            _logger.LogInformation(operationResult.Message);
            
            return Result.Success(dto)
                .WithMessage("Person successfully updated.");
        }
        
        _logger.LogError(
            $"Person has not been updated inside database. " +
            $"Reason: {operationResult.Message}");
        
        return Result.Failure()
            .WithMessage(operationResult.Message);
    }
}