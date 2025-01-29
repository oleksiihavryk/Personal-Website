using System.Text;
using Microsoft.Extensions.Logging;
using OleksiiHavryk.PersonalWebsite.Core.Dto;
using OleksiiHavryk.PersonalWebsite.Data;
using OleksiiHavryk.PersonalWebsite.Domain;
using ResultNet;

namespace OleksiiHavryk.PersonalWebsite.Tests.PersonManager;

public class SeedValueIfNotExistsTests
{
    [Fact]
    public async Task SeedValueIfNotExists_ObjectIsContaining_SeedingTerminated()
    {
        //arrange
        Person person = new();
        PersonDto seed = new();
        
        IPersonRepository repository = 
            Mock.Of<IPersonRepository>();
        ILogger<Core.PersonManager> logger = 
            Mock.Of<ILogger<Core.PersonManager>>();

        Mock.Get(repository)
            .Setup(opt => opt.GetAsync(
                It.IsAny<Guid>()))
            .ReturnsAsync(person);
        
        Core.PersonManager pm = new(logger, repository);
        //act

        var result = await pm.SeedValueIfNotExistsAsync(seed);

        //assert
        Assert.NotNull(result);
        Assert.True(result.IsFailure());
    }
    [Fact]
    public async Task SeedValueIfNotExists_ObjectIsNotContaining_SeedingProceeded()
    {
        //arrange
        PersonDto seed = GenerateDto();
        Person person = GeneratePerson();
        
        IPersonRepository repository = 
            Mock.Of<IPersonRepository>();
        ILogger<Core.PersonManager> logger = 
            Mock.Of<ILogger<Core.PersonManager>>();

        Mock.Get(repository)
            .Setup(opt => opt.GetAsync(
                It.IsAny<Guid>()))
            .ReturnsAsync(Result.Failure<Person>());
        Mock.Get(repository)
            .Setup(opt => opt.CreateAsync(
                It.Is<Person>(
                    p => IfPersonIsIdentical(p, seed))))
            .ReturnsAsync(Result.Success(person));
        
        Core.PersonManager pm = new(logger, repository);
        //act

        var result = await pm.SeedValueIfNotExistsAsync(seed);

        //assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess());
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
    private PersonDto GenerateDto() => new()
    {
        Name = "1",
        About = "1",
        Contacts = new()
        {
            Email = "1",
            Github = "1",
            Gitlab = "1",
            LinkedIn = "1",
            Phone = "1",
            Telegram = "1"
        },
        Resume = new()
        {
            DisplayName = "1",
            FileName = "1",
            Data = [0x0]
        },
        Projects = new()
        {
            Projects =
            [
                new()
                {
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
    private bool IfPersonIsIdentical(Person person, PersonDto personDto) =>
        person.Name == personDto.Name &&
        person.About == personDto.About &&
        person.Contacts.Email == personDto.Contacts?.Email &&
        person.Contacts.Phone == personDto.Contacts?.Phone &&
        person.Contacts.Telegram == personDto.Contacts?.Telegram &&
        person.Contacts.Gitlab == personDto.Contacts?.Gitlab &&
        person.Contacts.Github == personDto.Contacts?.Github &&
        person.Contacts.LinkedIn == personDto.Contacts?.LinkedIn &&
        person.Resume?.DisplayName == personDto.Resume?.DisplayName &&
        person.Resume?.FileName == personDto.Resume?.FileName && 
        Encoding.UTF8.GetString(person.Resume?.Data ?? []) == 
        Encoding.UTF8.GetString(personDto.Resume?.Data ?? []) &&
        ProjectsCollectionsIsEqual(person, personDto);

    private bool ProjectsCollectionsIsEqual(Person person, PersonDto personDto)
    {
        var arr1 = person.Projects?
            .ProjectsCollection
            .Select(x => new ProjectDto()
            {
                Name = x.Name,
                Description = x.Description,
                GithubUrl = x.GithubUrl,
                ImageUrl = x.ImageUrl,
                SiteUrl = x.SiteUrl,
                Show = x.Show,
            })
            .ToArray() ?? [];

        var arr2 = personDto.Projects?
            .Projects?
            .ToArray() ?? [];
        
        if (arr1.Length != arr2.Length)
        {
            return false;
        }

        Comparer<ProjectDto> def = Comparer<ProjectDto>.Create(
            (x, y) =>
            {
                var namesIsEqual = 
                    x.Name.CompareTo(y.Name);
                if (namesIsEqual != 0)
                {
                    return namesIsEqual;
                }
                
                var descriptionIsEqual = 
                    x.Description.CompareTo(y.Description);
                if (descriptionIsEqual != 0)
                {
                    return descriptionIsEqual;
                }
                
                var githubUrlIsEqual =
                    x.GithubUrl.CompareTo(y.GithubUrl);
                if (githubUrlIsEqual != 0)
                {
                    return githubUrlIsEqual;
                }
                
                var siteUrlIsEqual = 
                    x.SiteUrl.CompareTo(y.SiteUrl);
                if (siteUrlIsEqual != 0)
                {
                    return siteUrlIsEqual;
                }
                
                var imageUrlIsEqual = x.ImageUrl.CompareTo(y.ImageUrl);
                if (imageUrlIsEqual != 0)
                {
                    return imageUrlIsEqual;
                }

                return Convert.ToInt32(x.Show) - Convert.ToInt32(y.Show);
            });
        
        Array.Sort(arr1, def);
        Array.Sort(arr2, def);

        for (int i = 0; i < arr1.Length; i++)
        {
            var el1 = arr1[i];
            var el2 = arr2[i];

            if (def.Compare(el1, el2) != 0)
            {
                return false;
            }
        }

        return true;
    }
}