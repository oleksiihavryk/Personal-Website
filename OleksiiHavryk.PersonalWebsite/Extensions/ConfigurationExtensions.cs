using OleksiiHavryk.PersonalWebsite.Constants;
using OleksiiHavryk.PersonalWebsite.Core.Dto;

namespace OleksiiHavryk.PersonalWebsite.Extensions;

/// <summary>
///     Class for containing extension methods
///     for the IConfigurationManager interface. 
/// </summary>
public static class ConfigurationExtensions
{
    public static string GetDefaultConnectionString(
        this IConfigurationManager config) =>
        config.GetConnectionString(
            name: DatabaseConstants.DefaultDatabaseConnectionStringName) 
        ?? throw new ApplicationException(
            "Database connection string is missing.");
    public static PersonDto GetPersonSeed(
        this IConfigurationManager config) =>
        config.GetSection("Seed:Person")
            .Get<PersonDto>() 
        ?? throw new ApplicationException(
            "Person seed is empty or not found.");
}