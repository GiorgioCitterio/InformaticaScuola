using EsercizioPreVerifica.Data;
using EsercizioPreVerifica.Model;
using EsercizioPreVerifica.ModelDTO;
using EsercizioPreVerifica.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EsercizioPreVerifica.Endpoints
{
    public static class RegistaEndpoints
    {
        public static void MapRegistaEndpoints(this WebApplication app)
        {
            var registi = app.MapGroup("/registi");

            registi.MapGet("/", async(FilmDbContext db) =>
                Results.Ok(await db.Registas.Select(r => new RegistaDTO(r)).ToListAsync()));

            registi.MapGet("/{registaId}", async (FilmDbContext db, int registaId) =>
            {
                Regista? regista = await db.Registas.FindAsync(registaId);
                if(regista is null) return Results.NotFound();
                return Results.Ok(new RegistaDTO(regista));
            });

            registi.MapPost("/", async (FilmDbContext db, RegistaDTO registaDTO, IValidator<RegistaDTO> validator) =>
            {
                var validatoreRegista = await validator.ValidateAsync(registaDTO);
                if (!validatoreRegista.IsValid)
                    return Results.ValidationProblem(validatoreRegista.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Regista regista = new()
                {
                    Cognome = registaDTO.Cognome,
                    Nazionalità = registaDTO.Nazionalità,
                    Nome = registaDTO.Nome,
                };
                await db.Registas.AddAsync(regista);
                await db.SaveChangesAsync();
                return Results.Created("/registi", new RegistaDTO(regista));
            });

            registi.MapPut("/{registaId}", async (FilmDbContext db, int registaId, RegistaDTO registaDTO, IValidator<RegistaDTO> validator) =>
            {
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                var validatoreRegista = await validator.ValidateAsync(registaDTO);
                if (!validatoreRegista.IsValid)
                    return Results.ValidationProblem(validatoreRegista.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                regista.Nome = registaDTO.Nome;
                regista.Cognome = registaDTO.Cognome;
                regista.Nazionalità = registaDTO.Nazionalità;
                await db.SaveChangesAsync();
                return Results.Ok(new RegistaDTO(regista));
            });

            registi.MapDelete("/{registaId}", async (FilmDbContext db, int registaId) =>
            {
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                var righeDaEliminare = db.Films.Where(f => f.RegistaId == registaId);
                db.Films.RemoveRange(righeDaEliminare);
                db.Registas.Remove(regista);
                await db.SaveChangesAsync();
                return Results.Ok(new RegistaDTO(regista));
            });
        }
    }
}
