using Microsoft.EntityFrameworkCore;
using OleksiiHavryk.PersonalWebsite.Data.Extensions;
using OleksiiHavryk.PersonalWebsite.Domain;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Data;

/// <summary>
///     The repository pattern class for the Person class.
/// </summary>
public class PersonRepository : IPersonRepository
{
    private readonly DefaultDbContext _dbContext;

    public PersonRepository(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<Person>> GetAsync(Guid id)
    {
        Result<Person> result;


        try
        {
            var person = await _dbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);
        
            if (person is null)
            {
                result = Result.Failure<Person>()
                    .WithMessage("Person is not found by passed identifier.");
            }
            else
            {
                result = Result.Success(person)
                    .WithMessage("Person is found.");
            }
        }
        catch (Exception e)
        {
            result = Result.Failure<Person>()
                .WithMessage("Person is not found.")
                .WithMessage(e.Message);
        }

        return result;
    }
    public async Task<Result<Person>> CreateAsync(Person person)
    {
        Result<Person> result;
        
        try
        {
            var entry = await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();

            result = Result.Success(entry.Entity)
                .WithMessage("Person is created.");
        }
        catch (Exception ex)
        {
            result = Result.Failure<Person>()
                .WithMessage("Person is not created.")
                .WithError(ex);
        }

        return result;
    }
    public async Task<Result<Person>> UpdateAsync(Person person)
    {
        Result<Person> result;
        
        try
        {
            var entity = await _dbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == person.Id);

            if (entity is null)
            {
                result = Result.Failure<Person>()
                    .WithMessage("Person is not found by passed identifier.");
                
                return result;
            }

            entity.Name = person.Name;
            entity.About = person.About;

            entity.UpdateContacts(person.Contacts);
            entity.UpdateResume(person.Resume);
            entity.UpdateProjects(person.Projects);
            
            await _dbContext.SaveChangesAsync();

            result = Result.Success(entity)
                .WithMessage("Person is updated.");
        }
        catch (Exception ex)
        {
            result = Result.Failure<Person>()
                .WithMessage("Person is not updated.")
                .WithError(ex);
        }

        return result;
    }
    public async Task<Result> DeleteAsync(Guid id)
    {
        Result result;

        try
        {
            var entity = await _dbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity is null)
            {
                result = Result.Failure()
                    .WithMessage("Person is not found by passed identifier.");
                
                return result;
            }
            
            _dbContext.Persons.Remove(entity);

            await _dbContext.SaveChangesAsync();
            
            result = Result.Success()
                .WithMessage("Person is deleted.");
        }
        catch (Exception ex)
        {
            result = Result.Failure()
                .WithMessage("Person is not deleted.")
                .WithError(ex);
        }

        return result;
    }
}
