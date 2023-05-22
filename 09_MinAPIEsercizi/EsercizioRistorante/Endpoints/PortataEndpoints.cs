using EsercizioRistorante.Data;
using EsercizioRistorante.Model;
using EsercizioRistorante.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace EsercizioRistorante.Endpoints
{
    public static class PortataEndpoints
    {
        public static void MapPortataEndpoints(this WebApplication webApplication)
        {
            var portata = webApplication.MapGroup("/portata/{piattoId}/{chefId}");
            var chef = webApplication.MapGroup("/chef/{chefId}/portata");

            portata.MapPost("/", async (RistoranteDbContext db, PortataDTO portataDTO, int piattoId, int chefId) =>
            {
                Piatto? piatto = await db.Piattos.FindAsync(piattoId);
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null || piatto is null) return Results.NotFound();
                Portata portata = new()
                {
                    ChefId = chefId,
                    PiattoId = piattoId,
                    NumeroPorzioni = portataDTO.NumeroPorzioni
                };
                await db.Portatas.AddAsync(portata);
                await db.SaveChangesAsync();
                return Results.Created($"/portata/{piattoId}/{chefId}", new PortataDTO(portata));
            });

            portata.MapDelete("/", async (RistoranteDbContext db, int piattoId, int chefId) =>
            {
                Piatto? piatto = await db.Piattos.FindAsync(piattoId);
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null || piatto is null) return Results.NotFound();
                var portate = await db.Portatas.Where(p => p.ChefId == chefId && p.PiattoId == piattoId).ToListAsync();
                db.Portatas.RemoveRange(portate);
                await db.SaveChangesAsync();
                List<PortataDTO> portataDTOs = portate.Select(p => new PortataDTO(p)).ToList();
                return Results.Ok(portataDTOs);
            });

            chef.MapGet("/", async (RistoranteDbContext db, int chefId) =>
            {
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null) return Results.NotFound();
                var portate = await db.Portatas.Where(p => p.ChefId == chefId).ToListAsync();
                List<PortataDTO> portataDTOs = portate.Select(p => new PortataDTO(p)).ToList();
                return Results.Ok(portataDTOs);
            });
        }
    }
}
