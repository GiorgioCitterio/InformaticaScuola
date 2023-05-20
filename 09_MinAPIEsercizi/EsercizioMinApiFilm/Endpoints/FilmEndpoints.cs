using EsercizioMinApiFilm.Data;
using EsercizioMinApiFilm.Model;
using EsercizioMinApiFilm.ModelDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;
using EsercizioMinApiFilm.Validator;

namespace EsercizioMinApiFilm.Endpoints
{
    public static class FilmEndpoints
    {
        public static void MapFilmEndpoints(this WebApplication app)
        {
            var regista = app.MapGroup("/regista/{registaId}/film");
            var film = app.MapGroup("/film");

            regista.MapGet("/", async (CinemaDbContext db, int registaId) =>
            {
                var filmRegista = await db.Films.Where(f => f.RegistaId == registaId).ToListAsync();
                if (filmRegista is null) return Results.NotFound();
                List<FilmDTO> filmDTOs = filmRegista.Select(f => new FilmDTO(f)).ToList();
                return Results.Ok(filmDTOs);
            });

            regista.MapPost("/", async (CinemaDbContext db, int registaId, FilmDTO filmDTO, IValidator<FilmDTO> validator) =>
            {
                var validatorFilm = await validator.ValidateAsync(filmDTO);
                if (!validatorFilm.IsValid)
                    return Results.ValidationProblem(validatorFilm.ToDictionary(),
                       statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Regista? regista = await db.Registas.FindAsync(registaId);
                if (regista is null) return Results.NotFound();
                Film film = new()
                {
                    Titolo = filmDTO.Titolo,
                    DataDiProduzione = filmDTO.DataDiProduzione,
                    Durata = filmDTO.Durata,
                    RegistaId = registaId
                };
                await db.Films.AddAsync(film);
                await db.SaveChangesAsync();
                return Results.Created($"/regista/{film.RegistaId}/film", new FilmDTO(film));
            });

            film.MapGet("/", async (CinemaDbContext db) =>
                Results.Ok(await db.Films.Select(f => new FilmDTO(f)).ToListAsync()));

            film.MapGet("/{filmId}", async (CinemaDbContext db, int filmId) =>
            {
                Film? film = await db.Films.FindAsync(filmId);
                if (film is null) return Results.NotFound();
                return Results.Ok(new FilmDTO(film));
            });

            film.MapPut("/{filmId}", async (CinemaDbContext db, int filmId, FilmDTO filmDTO, IValidator<FilmDTO> validator) =>
            {
                var validatorFilm = await validator.ValidateAsync(filmDTO);
                if (!validatorFilm.IsValid)
                    return Results.ValidationProblem(validatorFilm.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                //Film? film = await db.Films.Where(f => f.FilmId == filmId).FirstOrDefaultAsync();
                Film? film = await db.Films.FindAsync(filmId);
                if (film is null) return Results.NotFound();
                film.Durata = filmDTO.Durata;
                film.DataDiProduzione = filmDTO.DataDiProduzione;
                film.Titolo = filmDTO.Titolo;
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            film.MapDelete("/{filmId}", async (CinemaDbContext db, int filmId) =>
            {
                Film? film = await db.Films.FindAsync(filmId);
                if (film is null) return Results.NotFound();
                var righe = db.Proieziones.Where(p => p.FilmId.Equals(filmId));
                db.Proieziones.RemoveRange(righe);
                db.Films.Remove(film);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}
