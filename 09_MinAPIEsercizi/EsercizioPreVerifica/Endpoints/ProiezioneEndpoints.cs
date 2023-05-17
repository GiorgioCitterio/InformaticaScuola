using EsercizioPreVerifica.Data;
using EsercizioPreVerifica.Model;
using EsercizioPreVerifica.ModelDTO;

namespace EsercizioPreVerifica.Endpoints
{
    public static class ProiezioneEndpoints
    {
        public static void MapProiezioneEndpoints(this WebApplication app)
        {
            var proiezioni = app.MapGroup("/proiezioni/{filmId}/{cinemaId}");

            proiezioni.MapPost("/", async(FilmDbContext db, int filmId, int cinemaId, ProiezioneDTO proiezioneDTO) =>
            {
                Film? film = await db.Films.FindAsync(filmId);
                Cinema? cinema = await db.Cinemas.FindAsync(cinemaId);
                if (cinema is null || film is null) return Results.NotFound();
                Proiezione proiezione = new()
                {
                    CinemaId = cinemaId,
                    FilmId = filmId,
                    Data = proiezioneDTO.Data,
                    Ora = proiezioneDTO.Ora
                };
                await db.Proieziones.AddAsync(proiezione);
                await db.SaveChangesAsync();
                return Results.Created($"/proiezioni/{filmId}/{cinemaId}", new ProiezioneDTO(proiezione));
            });
        }
    }
}
