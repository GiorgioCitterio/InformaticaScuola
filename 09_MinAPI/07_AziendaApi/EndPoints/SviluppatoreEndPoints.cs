using _07_AziendaApi.Data;
using _07_AziendaApi.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace _07_AziendaApi.EndPoints;

public static class SviluppatoreEndPoints
{
    public static void MapSviluppatoreEndPoints(this WebApplication app)
    {
        app.MapGet("/sviluppatori", async(AziendaDbContext db)=>
            Results.Ok(await db.Sviluppatori.Select(s => new SviluppatoreDTO(s)).ToListAsync()));
    }
}