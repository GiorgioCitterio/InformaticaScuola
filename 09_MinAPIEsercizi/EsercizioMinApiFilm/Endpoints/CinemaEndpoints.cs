using EsercizioMinApiFilm.Data;
using EsercizioMinApiFilm.Model;
using EsercizioMinApiFilm.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace EsercizioMinApiFilm.Endpoints;

public static class CinemaEndpoints
{
    public static void MapCinemaEndpoints(this WebApplication app)
    {
        var cinema = app.MapGroup("/cinema");

        cinema.MapGet("/", async (CinemaDbContext db) =>
            Results.Ok(await db.Cinemas.Select(c => new CinemaDTO(c)).ToListAsync()));

        cinema.MapPost("/", async (CinemaDbContext db, CinemaDTO cinemaDTO) =>
        {
            Cinema cinema = new()
            {
                CinemaId = cinemaDTO.CinemaId,
                Città = cinemaDTO.Città,
                Indirizzo = cinemaDTO.Indirizzo,
                Nome = cinemaDTO.Nome
            };
            await db.Cinemas.AddAsync(cinema);
            await db.SaveChangesAsync();
            return Results.Created("/cinema", new CinemaDTO(cinema));
        });

        cinema.MapGet("/{cinemaId}", async (CinemaDbContext db, int cinemaId) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            if (cinema is null) return Results.NotFound();
            return Results.Ok(new CinemaDTO(cinema));
        });
        
        cinema.MapPut("/{cinemaId}", async (CinemaDbContext db, int cinemaId, CinemaDTO cinemaDTO) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            if (cinema is null) return Results.NotFound();
            cinema.Città = cinemaDTO.Città;
            cinema.Indirizzo = cinemaDTO.Indirizzo;
            cinema.Nome = cinemaDTO.Nome;
            await db.SaveChangesAsync();
            return Results.Ok();
        });

        cinema.MapDelete("/{cinemaId}", async (CinemaDbContext db, int cinemaId) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            if (cinema is null) return Results.NotFound();
            var righeDaEliminare = db.Proieziones.Where(p => p.CinemaId == cinemaId);
            db.Proieziones.RemoveRange(righeDaEliminare);
            db.Cinemas.Remove(cinema);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
    }
}