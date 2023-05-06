using _07_AziendaApi.Data;
using _07_AziendaApi.Model;
using _07_AziendaApi.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace _07_AziendaApi.EndPoints;

public static class ProdottoEndPoints
{
    public static void MapProdottoEndPoints(this WebApplication app)
    {
        app.MapGet("/aziende/{aziendaId}/prodotti", async (AziendaDbContext db, int aziendaId) =>
        {
            Azienda? azienda = await db.Aziende.Where(a => a.AziendaId == aziendaId)
                .Include(a => a.Prodotti).FirstOrDefaultAsync();
            if (azienda is not null) return Results.Ok(azienda.Prodotti.Select(p => new ProdottoDTO(p)).ToList());
            return Results.NotFound();
        });

        app.MapPost("/aziende/{aziendaId}/prodotti", async (AziendaDbContext db, ProdottoDTO prodottoDTO, int aziendaId) =>
        {
            Azienda? azienda = await db.Aziende.FindAsync(aziendaId);
            if (azienda is null) return Results.NotFound();
            Prodotto prodotto = new()
                { Nome = prodottoDTO.Nome, Descrizione = prodottoDTO.Descrizione, AziendaId = prodottoDTO.AziendaId };
            await db.Prodotti.AddAsync(prodotto);
            await db.SaveChangesAsync();
            return Results.Created($"/aziende/{aziendaId}/prodotti/{prodotto.ProdottoId}", new ProdottoDTO(prodotto));
        });

        app.MapGet("/prodotti", async (AziendaDbContext db) => 
            Results.Ok(await db.Prodotti.Select(x => new ProdottoDTO(x)).ToListAsync()));

        app.MapGet("/prodotti/{prodottoId}", async (AziendaDbContext db, int prodottoId) =>
        {
            Prodotto? prodotto = await db.Prodotti.Where(p => p.ProdottoId == prodottoId).FirstOrDefaultAsync();
            if (prodotto is null) return Results.NotFound();
            return Results.Ok(new ProdottoDTO(prodotto));
        });

        app.MapPut("/prodotti/{prodottoId}", async (AziendaDbContext db, int prodottoId, ProdottoDTO prodottoDto) =>
        {
            Prodotto? prodottoDaCambiare = await db.Prodotti.Where(p => p.ProdottoId == prodottoId).FirstOrDefaultAsync();
            if (prodottoDaCambiare is null) return Results.NotFound();
            prodottoDaCambiare.Descrizione = prodottoDto.Descrizione;
            prodottoDaCambiare.Nome = prodottoDto.Nome;
            await db.SaveChangesAsync();
            return Results.Ok();
        });

        app.MapDelete("/prodotti/{prodottoId}", async (AziendaDbContext db, int prodottoId) =>
        {
            Prodotto? prodotto = await db.Prodotti.Where(p => p.ProdottoId == prodottoId).FirstOrDefaultAsync();
            if (prodotto is null) return Results.NotFound();
            var righeDaEliminareInSviluppaProdotti = 
                db.SviluppaProdotti.Where(sp => sp.ProdottoId == prodottoId);
            db.SviluppaProdotti.RemoveRange(righeDaEliminareInSviluppaProdotti);
            db.Remove(prodotto);
            await db.SaveChangesAsync();
            return Results.Ok();
        });
    }
}