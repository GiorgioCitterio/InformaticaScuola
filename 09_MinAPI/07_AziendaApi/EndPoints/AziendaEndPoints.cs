using _07_AziendaApi.Data;
using _07_AziendaApi.Model;
using _07_AziendaApi.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace _07_AziendaApi.EndPoints
{
    public static class AziendaEndPoints
    {
        public static void MapAziendaEndpoints(this WebApplication app)
        {
            //qui metto le rotte
            app.MapGet("/aziende", async (AziendaDbContext db) =>
                Results.Ok(await db.Aziende.Select(x => new AziendaDTO(x)).ToListAsync()));
            
            app.MapPost("/aziende", async (AziendaDbContext db, AziendaDTO aziendaDTO) =>
            {
                Azienda azienda = new() { Nome = aziendaDTO.Nome, Indirizzo = aziendaDTO.Indirizzo };
                await db.Aziende.AddAsync(azienda);
                await db.SaveChangesAsync();
                return Results.Created($"/aziende/{azienda.AziendaId}", new AziendaDTO(azienda));
            });

            app.MapGet("/aziende/{aziendaId}", async (AziendaDbContext db, int id) =>
            {
                var azienda = await db.Aziende.FindAsync(id);
                if(azienda is Azienda)
                    return Results.Ok(new AziendaDTO(azienda));
                return Results.NotFound();
            });

            app.MapPut("/aziende/{aziendaId}", async (AziendaDbContext db, int id, AziendaDTO azienda ) =>
            {
                var aziendaDaModificare = await db.Aziende.FindAsync(id);
                if(aziendaDaModificare is null) return Results.NotFound();
                aziendaDaModificare.Nome = azienda.Nome;
                aziendaDaModificare.Indirizzo = azienda.Indirizzo;
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapDelete("/aziende/{aziendaId}", async (AziendaDbContext db, int id) =>
            {
                var azienda = await db.Aziende.FindAsync(id);
                if(azienda is null) return Results.NotFound();
                db.Aziende.Remove(azienda);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}
