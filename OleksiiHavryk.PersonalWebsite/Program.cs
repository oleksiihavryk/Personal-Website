using OleksiiHavryk.PersonalWebsite.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetDefaultConnectionString();
builder.Services.AddDatabase(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();