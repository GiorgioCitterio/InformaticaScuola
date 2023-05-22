using EsercizioRistorante.Data;
using EsercizioRistorante.Model;
using EsercizioRistorante.ModelDTO;
using EsercizioRistorante.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EsercizioRistorante.Endpoints
{
    public static class PiattoEndpoints
    {
        public static void MapPiattoEndpoints(this WebApplication app)
        {
            var ristorante = app.MapGroup("/ristorante/{ristoranteId}/piatto");
            var piatto = app.MapGroup("/piatto");

            ristorante.MapGet("/", async (RistoranteDbContext db, int ristoranteId) =>
            {
                Ristorante? ristorante = await db.chef.FindAsync(ristoranteId);
                if (ristorante is null) return Results.NotFound();
                var piatti = await db.Piattos.Where(p => p.RistoranteId == ristoranteId).ToListAsync();
                if(piatti is null) return Results.NotFound();
                var piattiDTO = piatti.Select(p => new PiattoDTO(p)).ToList();
                return Results.Ok(piattiDTO);
            });

            ristorante.MapPost("/", async (RistoranteDbContext db, int ristoranteId, PiattoDTO piattoDTO, IValidator<PiattoDTO> validator) =>
            {
                var validatorPiatto = await validator.ValidateAsync(piattoDTO);
                if (!validatorPiatto.IsValid)
                    return Results.ValidationProblem(validatorPiatto.ToDictionary(),
                        statusCode:(int)HttpStatusCode.UnprocessableEntity);
                Ristorante? ristorante = await db.chef.FindAsync(ristoranteId);
                if (ristorante is null) return Results.NotFound();
                Piatto piatto = new()
                {
                    Costo = piattoDTO.Costo,
                    NomePiatto = piattoDTO.NomePiatto,
                    RistoranteId = ristoranteId,
                };
                await db.Piattos.AddAsync(piatto);
                await db.SaveChangesAsync();
                return Results.Created($"/ristorante/{ristoranteId}/piatto", new PiattoDTO(piatto));
            });

            piatto.MapGet("/", async(RistoranteDbContext db) =>
                Results.Ok(await db.Piattos.Select(p => new PiattoDTO(p)).ToListAsync()));

            piatto.MapGet("/{piattoId}", async (RistoranteDbContext db, int piattoId) =>
            {
                Piatto? piatto = await db.Piattos.FindAsync(piattoId);
                if (piatto is null) return Results.NotFound();
                return Results.Ok(new PiattoDTO(piatto));
            });

            piatto.MapPut("/{piattoId}", async (RistoranteDbContext db, int piattoId, PiattoDTO piattoDTO, IValidator<PiattoDTO> validator) =>
            {
                var validatorPiatto = await validator.ValidateAsync(piattoDTO);
                if (!validatorPiatto.IsValid)
                    return Results.ValidationProblem(validatorPiatto.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Piatto? piatto = await db.Piattos.FindAsync(piattoId);
                if (piatto is null) return Results.NotFound();
                piatto.NomePiatto = piattoDTO.NomePiatto;
                piatto.Costo = piattoDTO.Costo;
                await db.SaveChangesAsync();
                return Results.Ok(new PiattoDTO(piatto));
            });

            piatto.MapDelete("/{piattoId}", async (RistoranteDbContext db, int piattoId) =>
            {
                Piatto? piatto = await db.Piattos.FindAsync(piattoId);
                if (piatto is null) return Results.NotFound();
                db.Piattos.Remove(piatto);
                await db.SaveChangesAsync();
                return Results.Ok(new PiattoDTO(piatto));
            });
        }
    }
}
