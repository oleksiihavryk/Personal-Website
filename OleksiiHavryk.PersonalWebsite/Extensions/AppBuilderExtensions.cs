using OleksiiHavryk.PersonalWebsite.Core;
using OleksiiHavryk.PersonalWebsite.Core.Dto;

namespace OleksiiHavryk.PersonalWebsite.Extensions;

/// <summary>
///     Class for containing extension methods
///     for the WebApplicationBuilder interface. 
/// </summary>
public static class AppBuilderExtensions
{
    public static async Task<WebApplication> BuildWithSeed(
        this WebApplicationBuilder builder,
        PersonDto person)
    {
        var app = builder.Build();

        var scope = app.Services.CreateScope(); 
        var pm = scope.ServiceProvider.GetRequiredService<IPersonManager>();
        await pm.SeedValueIfNotExistsAsync(person);
        
        return app;
    }
}