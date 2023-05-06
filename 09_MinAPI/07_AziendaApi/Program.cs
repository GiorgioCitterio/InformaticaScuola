using _07_AziendaApi.Data;
using _07_AziendaApi.EndPoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//aggiunge lo swagger di default
//fa in modo che l'utente nel db veda il nome senza DTO
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Azienda API",
        Description = "Manage your company assets via API",
        Version = "v1"
    });
    /*
    https://stackoverflow.com/questions/40644052/rename-model-in-swashbuckle-6-swagger-with-asp-net-core-web-api
    https://stackoverflow.com/a/40684060
    */
    c.CustomSchemaIds(schemaIdStrategy);
    static string schemaIdStrategy(Type currentClass)
    {
        string returnedValue = currentClass.Name;
        if (returnedValue.EndsWith("DTO"))
            returnedValue = returnedValue.Replace("DTO", string.Empty);
        return returnedValue;
    }
});

//riferimento al db
var connectionString = builder.Configuration.GetConnectionString("AziendaAPIConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<AziendaDbContext>(
        dbContextOptions => dbContextOptions
            .UseMySql(connectionString, serverVersion)
            // The following three options help with debugging, but should
            // be changed or removed for production.
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "ciao");
app.MapAziendaEndpoints();
app.MapProdottoEndPoints();
app.MapSviluppatoreEndPoints();
app.MapSviluppaProdottoEndPoints();

app.Run();