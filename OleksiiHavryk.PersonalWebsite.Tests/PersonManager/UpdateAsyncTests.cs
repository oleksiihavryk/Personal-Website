using System.Text;
using Microsoft.Extensions.Logging;
using OleksiiHavryk.PersonalWebsite.Core.Dto;
using OleksiiHavryk.PersonalWebsite.Data;
using OleksiiHavryk.PersonalWebsite.Domain;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Tests.PersonManager;

public class UpdateAsyncTests
{
    [Fact]
    public async Task UpdateAsync_ObjectIsContaining_UpdatingSucceeded()
    {
        //arrange
        Person person = GeneratePerson();
        PersonDto updating = new();
        
        IPersonRepository repository = 
            Mock.Of<IPersonRepository>();
        ILogger<Core.PersonManager> logger = 
            Mock.Of<ILogger<Core.PersonManager>>();

        Mock.Get(repository)
            .Setup(opt => opt.GetAsync(
                It.IsAny<Guid>()))
            .ReturnsAsync(person);

        Mock.Get(repository)
            .Setup(opt => opt.UpdateAsync(
                It.Is<Person>(p => p == person)))
            .ReturnsAsync(person);
        
        Core.PersonManager pm = new(logger, repository);
        
        //act
        var result = await pm.UpdateAsync(updating);

        //assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess());
    }
    [Fact]
    public async Task UpdateAsync_ObjectIsNotContaining_UpdatingFailed()
    {
        //arrange
        Person person = GeneratePerson();
        PersonDto updating = new();
        
        IPersonRepository repository = 
            Mock.Of<IPersonRepository>();
        ILogger<Core.PersonManager> logger = 
            Mock.Of<ILogger<Core.PersonManager>>();

        Mock.Get(repository)
            .Setup(opt => opt.GetAsync(
                It.IsAny<Guid>()))
            .ReturnsAsync(Result.Failure<Person>());

        Mock.Get(repository)
            .Setup(opt => opt.UpdateAsync(
                It.Is<Person>(p => p == person)))
            .ReturnsAsync(person);
        
        Core.PersonManager pm = new(logger, repository);
        
        //act
        var result = await pm.UpdateAsync(updating);

        //assert
        Assert.NotNull(result);
        Assert.True(result.IsFailure());
    }

    private Person GeneratePerson() => new()
    {
        Id = Guid.NewGuid(),
        Name = "1",
        About = "1",
        Contacts = new()
        {
            Id = Guid.NewGuid(),
            PersonId = Guid.NewGuid(),
            Email = "1",
            Github = "1",
            Gitlab = "1",
            LinkedIn = "1",
            Phone = "1",
            Telegram = "1"
        },
        Resume = new()
        {
            Id = Guid.NewGuid(),
            DisplayName = "1",
            FileName = "1",
            Data = [0x0]
        },
        Projects = new()
        {
            Id = Guid.NewGuid(),
            PersonId = Guid.NewGuid(),
            ProjectsCollection =
            [
                new()
                {
                    Id = Guid.NewGuid(),
                    ProjectsId = Guid.NewGuid(),
                    Name = "1",
                    Description = "1",
                    GithubUrl = "1",
                    ImageUrl = "1",
                    SiteUrl = "1",
                    Show = true
                }
            ]
        }
    };
}