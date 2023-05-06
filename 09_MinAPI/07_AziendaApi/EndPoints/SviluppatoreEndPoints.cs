using _07_AziendaApi.Data;
using _07_AziendaApi.Model;
using _07_AziendaApi.ModelDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _07_AziendaApi.EndPoints;

public static class SviluppatoreEndPoints
{
    public static void MapSviluppatoreEndPoints(this WebApplication app)
    {
        app.MapGet("/sviluppatori", async(AziendaDbContext db)=>
            Results.Ok(await db.Sviluppatori.Select(s => new SviluppatoreDTO(s)).ToListAsync()));

        app.MapPost("/aziende/{aziendaId}/sviluppatori", async (AziendaDbContext db, int aziendaId, SviluppatoreDTO sviluppatoreDto) =>
        {
            Azienda? azienda = await db.Aziende.FindAsync(aziendaId);
            if (azienda is null) return Results.NotFound();
            Sviluppatore sviluppatore = new Sviluppatore()
                { Nome = sviluppatoreDto.Nome, Cognome = sviluppatoreDto.Cognome, AziendaId = azienda.AziendaId };
            await db.Sviluppatori.AddAsync(sviluppatore);
            await db.SaveChangesAsync();
            return Results.Created("/aziende/{aziendaId}/sviluppatori/{sviluppatore.SviluppatoreId}",
                new SviluppatoreDTO(sviluppatore));
        });

        app.MapGet("/prodotti/{prodottoId}/sviluppatori", async (AziendaDbContext db, int prodottoId) =>
        {
            Prodotto? prodotto = await db.Prodotti.
                Where(p => p.ProdottoId == prodottoId).
                Include(p => p.SviluppaProdotti).
                ThenInclude(s => s.Sviluppatore).
                FirstOrDefaultAsync();
            if (prodotto is null) return Results.NotFound();
            return Results.Ok(prodotto.SviluppaProdotti.Select(x => new SviluppatoreDTO(x.Sviluppatore)).ToList());
        });
        
        app.MapGet("/aziende/{aziendaId}/sviluppatori", async (AziendaDbContext db, int aziendaId, [FromQuery(Name = "prodottoId")] int? prodottoId) =>
        {
            //questo è il caso in cui non è stato specificato il prodottoId nella query string
            //devo restituire l'elenco degli sviluppatori dell'azienda di cui è stato fornito l'aziendaId
            if (prodottoId is null)
            {
                Azienda? azienda = await db.Aziende.
                    Where(a => a.AziendaId == aziendaId).
                    Include(a => a.Sviluppatori).
                    FirstOrDefaultAsync();
                if (azienda is not null)
                {
                            return Results.Ok(azienda.Sviluppatori.Select(x => new SviluppatoreDTO(x)).ToList());
                }
                return Results.NotFound();
            }
            else //questo è il caso in cui è stato specificato anche il prodottoId
            {
                Prodotto? prodotto = await db.Prodotti.FindAsync(prodottoId);
                if (prodotto is null) return Results.NotFound();
                //devo controllare che il prodotto appartenga all'azienda specificata mediante AziendaId
                if(prodotto.AziendaId != aziendaId)
                {
                    return Results.BadRequest($"Il prodotto con prodottoId={prodottoId} non appartiene alla'azienda con aziendaId={aziendaId}");
                }
                //effettuo la join tra Sviluppatori e SviluppaProdotti per ottenere gli sviluppatori che 
                //hanno partecipato allo sviluppo di un determinato prodotto
                List<Sviluppatore> listaSviluppatori =
                    await db.Sviluppatori.Where(s => s.AziendaId == aziendaId).
                        Join(db.SviluppaProdotti.Where(sp => sp.ProdottoId == prodottoId),
                            s => s.SviluppatoreId,
                            sp => sp.SviluppatoreId,
                            (s, sp) => s).ToListAsync();
                return Results.Ok(listaSviluppatori.Select(s => new SviluppatoreDTO(s)));
            }
        });
        
        app.MapGet("/sviluppatori/{sviluppatoreId}", async (AziendaDbContext db, int sviluppatoreId) =>
        {
            Sviluppatore? sviluppatore = await db.Sviluppatori.FindAsync(sviluppatoreId);
            if (sviluppatore != null)
                return Results.Ok(new SviluppatoreDTO(sviluppatore));
            return Results.NotFound();
        });

        app.MapPut("/sviluppatori/{sviluppatoreId}", async (AziendaDbContext db, SviluppatoreDTO updateSviluppatore, int sviluppatoreId) =>
        {
            Sviluppatore? sviluppatore = await db.Sviluppatori.FindAsync(sviluppatoreId);
            if (sviluppatore is null) return Results.NotFound();
            sviluppatore.Nome = updateSviluppatore.Nome;
            sviluppatore.Cognome = updateSviluppatore.Cognome;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        app.MapDelete("/sviluppatori/{sviluppatoreId}", async (AziendaDbContext db, int sviluppatoreId) =>
        {
            Sviluppatore? sviluppatore = await db.Sviluppatori.FindAsync(sviluppatoreId);
            if (sviluppatore is null) return Results.NotFound();
            //elimino prima le righe in SviluppaProdotti
            //questa azione è necessaria perché è stato configurato l'opzione .OnDelete(DeleteBehavior.Restrict) sulla tabella SviluppaProdotto
            //nel collegamento sulla chiave esterna verso Sviluppatore
            //Se non avessimo impostato questa opzione sarebbe bastato eliminare lo sviluppatore e, a cascata, sarebbero state eliminate anche tutte le 
            //righe delle tabelle collegate tramite foreign key a quello sviluppatore.
            var righeDaEliminareInSviluppaProdotti = db.SviluppaProdotti.Where(sp => sp.SviluppatoreId == sviluppatoreId);
            db.SviluppaProdotti.RemoveRange(righeDaEliminareInSviluppaProdotti);
            //poi elimino il prodotto
            db.Sviluppatori.Remove(sviluppatore);
            //salvo le modifiche nel database
            await db.SaveChangesAsync();
            return Results.Ok();   

        });
    }
}