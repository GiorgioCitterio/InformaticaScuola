using EsercizioPreVerifica.Data;
using EsercizioPreVerifica.Model;
using EsercizioPreVerifica.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace EsercizioPreVerifica.Endpoints
{
    public static class CinemaEndpoints
    {
        public static void MapCinemaEndpoints(this WebApplication app)
        {
            var cinema = app.MapGroup("/cinemas");

            cinema.MapGet("/", async(FilmDbContext db) =>
                Results.Ok(await db.Cinemas.Select(c => new CinemaDTO(c)).ToListAsync()));

            cinema.MapPost("/", async (FilmDbContext db, CinemaDTO cinemaDTO) =>
            {
                Cinema cinema = new()
                {
                   Città = cinemaDTO.Città,
                   Indirizzo = cinemaDTO.Indirizzo,
                   Nome = cinemaDTO.Nome
                };
                await db.Cinemas.AddAsync(cinema);
                await db.SaveChangesAsync();
                return Results.Created("/cinemas", new CinemaDTO(cinema));
            });
        }
    }
}
