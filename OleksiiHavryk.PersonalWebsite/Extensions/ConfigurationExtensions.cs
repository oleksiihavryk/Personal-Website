using OleksiiHavryk.PersonalWebsite.Constants;

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
        ?? throw new ApplicationException();
}