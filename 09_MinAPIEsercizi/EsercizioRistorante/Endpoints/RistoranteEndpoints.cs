﻿using EsercizioRistorante.Data;
using EsercizioRistorante.Model;
using EsercizioRistorante.ModelDTO;
using Microsoft.EntityFrameworkCore;

namespace EsercizioRistorante.Endpoints
{
    public static class RistoranteEndpoints
    {
        public static void MapRistoranteEndpoints(this WebApplication app)
        {
            var ristorante = app.MapGroup("/ristorante");

            ristorante.MapGet("/", async (RistoranteDbContext db) =>
                Results.Ok(await db.Ristorantes.Select(r => new RistoranteDTO(r)).ToListAsync()));

            ristorante.MapPost("/", async (RistoranteDbContext db, RistoranteDTO ristoranteDTO) =>
            {
                Ristorante ristorante = new()
                {
                    Nome = ristoranteDTO.Nome,
                    Città = ristoranteDTO.Città
                };
                await db.Ristorantes.AddAsync(ristorante);
                await db.SaveChangesAsync();
                return Results.Created($"/ristorante/{ristorante.RistoranteId}", new RistoranteDTO(ristorante));
            });

            ristorante.MapGet("/{ristoranteId}", async (RistoranteDbContext db, int ristoranteId) =>
            {
                Ristorante? ristorante = await db.Ristorantes.FindAsync(ristoranteId);
                if(ristorante is null) return Results.NotFound();
                return Results.Ok(new RistoranteDTO(ristorante));
            });

            ristorante.MapPut("/{ristoranteId}", async(RistoranteDbContext db, int ristoranteId, RistoranteDTO ristoranteDTO) =>
            {
                Ristorante? ristorante = await db.Ristorantes.FindAsync(ristoranteId);
                if (ristorante is null) return Results.NotFound();
                ristorante.Città = ristoranteDTO.Città;
                ristorante.Nome = ristoranteDTO.Nome;
                await db.SaveChangesAsync();
                return Results.Ok(new RistoranteDTO(ristorante));
            });

            ristorante.MapDelete("/{ristoranteId}", async (RistoranteDbContext db, int ristoranteId) =>
            {
                Ristorante? ristorante = await db.Ristorantes.FindAsync(ristoranteId);
                if (ristorante is null) return Results.NotFound();
                var righeDaEliminare = db.Piattos.Where(p => p.RistoranteId.Equals(ristoranteId));
                db.Piattos.RemoveRange(righeDaEliminare);
                db.Ristorantes.Remove(ristorante);
                await db.SaveChangesAsync();
                return Results.Ok(new RistoranteDTO(ristorante));
            });
        }
    }
}
