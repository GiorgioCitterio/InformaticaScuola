using _07_AziendaApi.Data;
using _07_AziendaApi.Model;
using Microsoft.EntityFrameworkCore;
namespace _07_AziendaApi.EndPoints;

public static class SviluppaProdottoEndPoints 
{
  public static void MapSviluppaProdottoEndPoints(this WebApplication app) 
  {
    app.MapPost("/sviluppa-prodotto/{sviluppatoreId}/{prodottoId}",
      async (AziendaDbContext db, int sviluppatoreId, int prodottoId) => {
        Prodotto ? prodotto = await db.Prodotti.FindAsync(prodottoId);
        Sviluppatore ? sviluppatore = await db.Sviluppatori.FindAsync(sviluppatoreId);

        //controllo che l'associazione non sia già stata creata
        SviluppaProdotto ? rigaInTabella = await db.SviluppaProdotti.
        Where(sp => sp.SviluppatoreId == sviluppatoreId && sp.ProdottoId == prodottoId).
        FirstOrDefaultAsync();
        //la riga esiste già - nessuna azione da effettuare
        if (rigaInTabella is not null)
          return Results.NoContent();
        //la riga non esiste e ci sono prodotto e sviluppatore nelle rispettive tabelle
        if (prodotto != null && sviluppatore != null) {
          //controllo che sviluppatore e prodotto appartengano alla stessa azienda
          bool prodottoSviluppatoreStessaAzienda = prodotto.AziendaId == sviluppatore.AziendaId;
          //devo creare la riga in tabella
          if (prodottoSviluppatoreStessaAzienda) {
            var rigaDaCreare = new SviluppaProdotto() {
              ProdottoId = prodottoId, SviluppatoreId = sviluppatoreId
            };
            db.SviluppaProdotti.Add(rigaDaCreare);
            await db.SaveChangesAsync();
            return Results.NoContent();
          } else //sviluppatore e prodotto NON appartengano alla stessa azienda
          {
            return Results.BadRequest($"Sviluppatore e prodotto non appartengono alla stessa azienda");
          }
        } else //almeno uno dei due id non è stato trovato
        {
          return Results.NotFound();
        }
      });

    app.MapDelete("/sviluppa-prodotto/{sviluppatoreId}/{prodottoId}",
      async (AziendaDbContext db, int sviluppatoreId, int prodottoId) => {
        Prodotto ? prodotto = await db.Prodotti.FindAsync(prodottoId);
        Sviluppatore ? sviluppatore = await db.Sviluppatori.FindAsync(sviluppatoreId);
        if (sviluppatore != null && prodotto != null) {
          //controllo che l'associazione tra sviluppatore e prodotto esista
          SviluppaProdotto ? rigaInTabella = await db.SviluppaProdotti.
          Where(sp => sp.SviluppatoreId == sviluppatoreId && sp.ProdottoId == prodottoId).
          FirstOrDefaultAsync();
          //l'associazione esiste e va eliminata
          if (rigaInTabella != null) {
            db.SviluppaProdotti.Remove(rigaInTabella);
            await db.SaveChangesAsync();
            return Results.NoContent();
          } else //l'associazione non esiste
          {
            return Results.NotFound();
          }
        } else //non sono stati trovati lo sviluppatore e/o il prodotto
        {
          return Results.NotFound();
        }
      });
  }
}