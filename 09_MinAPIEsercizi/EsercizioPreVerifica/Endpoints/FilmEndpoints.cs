using EsercizioPreVerifica.Data;
using EsercizioPreVerifica.Model;
using EsercizioPreVerifica.ModelDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EsercizioPreVerifica.Endpoints
{
    public static class FilmEndpoints
    {
        public static void MapFilmEndpoints(this WebApplication app)
        {
            var registi = app.MapGroup("/registi/{registaId}/films");
            var films = app.MapGroup("/films");

            registi.MapGet("/", async (FilmDbContext db, int registaId) =>
            {
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                var filmi = await db.Films.Where(f => f.RegistaId == registaId).ToListAsync();
                if(filmi is null) return Results.NotFound();
                List<FilmDTO> filmDTOs = new();
                filmi.ForEach(f => filmDTOs.Add(new FilmDTO(f)));
                return Results.Ok(filmDTOs);
            });

            registi.MapPost("/", async (FilmDbContext db, int registaId, FilmDTO filmDTO, IValidator<FilmDTO> validator) =>
            {
                var filmValidator = await validator.ValidateAsync(filmDTO);
                if (!filmValidator.IsValid)
                    return Results.ValidationProblem(filmValidator.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                Film film = new()
                {
                    RegistaId = registaId,
                    DataDiProduzione = filmDTO.DataDiProduzione,
                    Durata = filmDTO.Durata,
                    Titolo = filmDTO.Titolo,
                };
                await db.Films.AddAsync(film);
                await db.SaveChangesAsync();
                return Results.Ok(new FilmDTO(film));
            });

            films.MapGet("/", async(FilmDbContext db)=>
                Results.Ok(await db.Films.Select(f => new FilmDTO(f)).ToListAsync()));

            films.MapGet("/{filmId}", async (FilmDbContext db, int filmId) =>
            {
                Film? film = await db.Films.FindAsync(filmId);
                if(film is null) return Results.NotFound();
                return Results.Ok(new FilmDTO(film));
            });

            films.MapPut("/{filmId}", async (FilmDbContext db, int filmId, FilmDTO filmDTO, IValidator<FilmDTO> validator) =>
            {
                var filmValidator = await validator.ValidateAsync(filmDTO);
                if (!filmValidator.IsValid)
                    return Results.ValidationProblem(filmValidator.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Film? film = await db.Films.FindAsync(filmId);
                if (film is null) return Results.NotFound();
                film.Durata = filmDTO.Durata;
                film.DataDiProduzione = filmDTO.DataDiProduzione;
                film.Titolo = filmDTO.Titolo;
                await db.SaveChangesAsync();
                return Results.Ok(new FilmDTO(film));
            });

            films.MapDelete("/{filmId}", async (FilmDbContext db, int filmId) =>
            {
                Film? film = await db.Films.FindAsync(filmId);
                if (film is null) return Results.NotFound();
                db.Films.Remove(film);
                await db.SaveChangesAsync();
                return Results.Ok(new FilmDTO(film));
            });
        }
    }
}
