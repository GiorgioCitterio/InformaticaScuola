using EsercizioPreVerifica.Data;
using EsercizioPreVerifica.Endpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("FilmAPIConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<FilmDbContext>(
        dbContextOptions => dbContextOptions
            .UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapFilmEndpoints();
app.MapRegistaEndpoints();
app.MapProiezioneEndpoints();
app.MapCinemaEndpoints();

app.Run();