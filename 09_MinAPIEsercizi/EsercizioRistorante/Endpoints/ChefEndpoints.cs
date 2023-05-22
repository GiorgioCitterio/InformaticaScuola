using EsercizioRistorante.Data;
using EsercizioRistorante.Model;
using EsercizioRistorante.ModelDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Net;

namespace EsercizioRistorante.Endpoints
{
    public static class ChefEndpoints
    {
        public static void MapChefEndpoints(this WebApplication application)
        {
            var chef = application.MapGroup("/chef");

            chef.MapGet("/", async(RistoranteDbContext db) =>
                Results.Ok(await db.Chefs.Select(c => new ChefDTO(c)).ToListAsync()));

            chef.MapPost("/", async (RistoranteDbContext db, ChefDTO chefDTO) =>
            {
                Chef chef = new()
                {
                    Nome = chefDTO.Nome,
                    DataDiNascita = chefDTO.DataDiNascita,
                };
                await db.Chefs.AddAsync(chef);
                await db.SaveChangesAsync();
                return Results.Created($"/ristorante/{chef.ChefId}", new ChefDTO(chef));
            });

            chef.MapGet("/{chefId}", async (RistoranteDbContext db, int chefId) =>
            {
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null) return Results.NotFound();
                return Results.Ok(new ChefDTO(chef));
            });

            chef.MapPut("/{chefId}", async (RistoranteDbContext db, int chefId, ChefDTO chefDTO) =>
            {
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null) return Results.NotFound();
                chef.DataDiNascita = chefDTO.DataDiNascita;
                chef.Nome = chefDTO.Nome;
                await db.SaveChangesAsync();
                return Results.Ok(new ChefDTO(chef));
            });

            chef.MapDelete("/{chefId}", async (RistoranteDbContext db, int chefId) =>
            {
                Chef? chef = await db.Chefs.FindAsync(chefId);
                if (chef is null) return Results.NotFound();
                var righeDaEliminare = db.Portatas.Where(p => p.ChefId == chefId);
                db.Portatas.RemoveRange(righeDaEliminare);
                db.Chefs.Remove(chef);
                await db.SaveChangesAsync();
                return Results.Ok(new ChefDTO(chef));
            });
        }
    }
}
