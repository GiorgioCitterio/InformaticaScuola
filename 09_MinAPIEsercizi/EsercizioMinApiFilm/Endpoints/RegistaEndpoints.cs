using System.Net;
using EsercizioMinApiFilm.Data;
using EsercizioMinApiFilm.Model;
using EsercizioMinApiFilm.ModelDTO;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace EsercizioMinApiFilm.Endpoints
{
    public static class RegistaEndpoints
    {
        public static void MapRegistaEndpoints(this WebApplication app)
        {
            var regista = app.MapGroup("/regista");

            regista.MapGet("/", async (CinemaDbContext db) =>
                Results.Ok(await db.Registas.Select(r => new RegistaDTO(r)).ToListAsync()));

            regista.MapPost("/", async (CinemaDbContext db, RegistaDTO registaDTO, IValidator<RegistaDTO> validator) =>
            {
                var validatorRegista = await validator.ValidateAsync(registaDTO);
                if (!validatorRegista.IsValid)
                    return Results.ValidationProblem(validatorRegista.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Regista regista = new()
                {
                    Nome = registaDTO.Nome,
                    Cognome = registaDTO.Cognome,
                    Nazionalità = registaDTO.Nazionalità,
                };
                await db.Registas.AddAsync(regista);
                await db.SaveChangesAsync();
                return Results.Created($"/regista/{regista.RegistaId}", new RegistaDTO(regista));
            });

            regista.MapGet("/{registaId}", async (CinemaDbContext db, int registaId) =>
            {
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                return Results.Ok(new RegistaDTO(regista));
            });

            regista.MapPut("/{registaId}", async (CinemaDbContext db, int registaId, RegistaDTO registaDTO, IValidator<RegistaDTO> validator) =>
            {
                var validatorRegista = await validator.ValidateAsync(registaDTO);
                if (!validatorRegista.IsValid)
                    return Results.ValidationProblem(validatorRegista.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                //Regista? registaDaModificare = await db.Registas.Where(r => r.RegistaId == registaId).FirstOrDefaultAsync();
                Regista? registaDaModificare = await db.Registas.FindAsync(registaId);
                if (registaDaModificare is null) return Results.NotFound();
                registaDaModificare.Nazionalità = registaDTO.Nazionalità;
                registaDaModificare.Nome = registaDTO.Nome;
                registaDaModificare.Cognome = registaDTO.Cognome;
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            regista.MapDelete("/{registaId}", async (CinemaDbContext db, int registaId) =>
            {
                Regista? registaDaEliminare = await db.Registas.FindAsync(registaId);
                if (registaDaEliminare is null) return Results.NotFound();
                var righeDaEliminare = db.Films.Where(f => f.RegistaId.Equals(registaId));
                db.Films.RemoveRange(righeDaEliminare);
                db.Registas.Remove(registaDaEliminare);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}