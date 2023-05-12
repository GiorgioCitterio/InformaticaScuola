using EsercizioMinApiFilm.Data;
using EsercizioMinApiFilm.Model;
using EsercizioMinApiFilm.ModelDTO;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EsercizioMinApiFilm.Endpoints;

public static class ProiezioneEndpoints
{
    public static void MapProiezioneEndpoints(this WebApplication app)
    {
        var proiezione = app.MapGroup("/proiezione/{cinemaId}/{filmId}");
        var cinema = app.MapGroup("/cinema/{cinemaId}/proiezione");
        var film = app.MapGroup("/film/{filmId}/proiezione");

        proiezione.MapPost("/", async (CinemaDbContext db, int cinemaId, int filmId, ProiezioneDTO proiezioneDTO) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            Film? film = await db.Films.FindAsync(filmId);
            if (cinema is null || film is null) return Results.NotFound();
            Proiezione proiezione = new()
            {
                CinemaId = cinemaId,
                FilmId = filmId,
                Ora = 23,
                Data = DateTime.Now
            };
            await db.Proieziones.AddAsync(proiezione);
            await db.SaveChangesAsync();
            return Results.Created($"/proiezione/{proiezione.CinemaId}/{proiezione.FilmId}", new ProiezioneDTO(proiezione));
        });

        
        proiezione.MapDelete("/", async (CinemaDbContext db, int cinemaId, int filmId) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            Film? film = await db.Films.FindAsync(filmId);
            if (cinema is null || film is null) return Results.NotFound();
            var righeDaEliminare = db.Proieziones.Where(c => c.CinemaId.Equals(cinemaId) && c.FilmId.Equals(filmId));
            db.Proieziones.RemoveRange(righeDaEliminare);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
        

        cinema.MapGet("/", async (CinemaDbContext db, int cinemaId) =>
        {
            Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
            if (cinema is null) return Results.NotFound();
            List<Proiezione>? proiezioni = await db.Proieziones.Where(p => p.CinemaId == cinemaId).ToListAsync();
            if (proiezioni.Count == 0) return Results.NotFound();
            List<ProiezioneDTO>? proiezioniDTO = new();
            proiezioni.ForEach(p => proiezioniDTO.Add(new ProiezioneDTO(p)));
            return Results.Ok(proiezioniDTO);
        });

        film.MapGet("/", async (CinemaDbContext db, int filmId) =>
        {
            Film? Film = await db.Films.FindAsync(filmId);
            if (film is null) return Results.NotFound();
            var proiezioni = await db.Proieziones.Where(p => p.FilmId == filmId).ToListAsync();
            if (proiezioni.Count == 0) return Results.NotFound();
            List<ProiezioneDTO>? proiezioniDTO = new();
            proiezioni.ForEach(p => proiezioniDTO.Add(new ProiezioneDTO(p)));
            return Results.Ok(proiezioniDTO);
        });
    }
}