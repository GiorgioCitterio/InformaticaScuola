using EsercizioMinApiFilm.Data;
using EsercizioMinApiFilm.Endpoints;
using EsercizioMinApiFilm.ModelDTO;
using EsercizioMinApiFilm.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<FilmDTO>, FilmDTOValidator>();
builder.Services.AddScoped<IValidator<RegistaDTO>, RegistaDTOValidator>();

var connectionString = builder.Configuration.GetConnectionString("FilmAPIConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<CinemaDbContext>(
        dbContextOptions => dbContextOptions
            .UseMySql(connectionString, serverVersion)
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

app.MapFilmEndpoints();
app.MapRegistaEndpoints();

app.Run();