using OleksiiHavryk.PersonalWebsite.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetDefaultConnectionString();
var seed = builder.Configuration.GetPersonSeed();

builder.Services.AddControllersWithViews(
    mvc => mvc.EnableEndpointRouting = false);

builder.Services.AddLogging();
builder.Services.AddDatabase(connectionString);
builder.Services.AddPersonManager();

var app = await builder.BuildWithSeed(seed);

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseMvcWithDefaultRoute();

await app.RunAsync();