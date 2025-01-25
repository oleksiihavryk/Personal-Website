using Microsoft.EntityFrameworkCore;
using OleksiiHavryk.PersonalWebsite.Core;
using OleksiiHavryk.PersonalWebsite.Data;

namespace OleksiiHavryk.PersonalWebsite.Extensions;

/// <summary>
///     Class for containing extension methods
///     for the IServiceCollection interface. 
/// </summary>
public static class ServicesExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<DefaultDbContext>(opt => 
            opt.UseSqlServer(connectionString));
        
        return services;
    }

    public static IServiceCollection AddPersonManager(
        this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonManager, PersonManager>();

        return services;
    }
}