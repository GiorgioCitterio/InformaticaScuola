using EsercizioRistorante.Data;
using EsercizioRistorante.Model;
using EsercizioRistorante.ModelDTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EsercizioRistorante.Endpoints
{
    public static class RistoranteEndpoints
    {
        public static void MapRistoranteEndpoints(this WebApplication app)
        {
            var ristorante = app.MapGroup("/ristorante");

            ristorante.MapGet("/", async (RistoranteDbContext db) =>
                Results.Ok(await db.Ristorantes.Select(r => new RistoranteDTO(r)).ToListAsync()));

            ristorante.MapPost("/", async (RistoranteDbContext db, RistoranteDTO ristoranteDTO, IValidator<RistoranteDTO> validator) =>
            {
                /*
                var validatorRistorante = await validator.ValidateAsync(ristoranteDTO);
                if (!validatorRistorante.IsValid)
                    return Results.ValidationProblem(validatorRistorante.ToDictionary(),
                        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                */
                Ristorante ristorante = new()
                {
                    Nome = ristoranteDTO.Nome,
                    Città = ristoranteDTO.Città
                };
                await db.Ristorantes.AddAsync(ristorante);
                await db.SaveChangesAsync();
                return Results.Created($"/ristorante/{ristorante.RistoranteId}", new RistoranteDTO(ristorante));
            }).AddEndpointFilter(async (context, next) =>
            {
                RistoranteDTO? rist = context.Arguments.FirstOrDefault(r => r.GetType().Equals(typeof(RistoranteDTO))) as RistoranteDTO;
                IValidator<RistoranteDTO> validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<RistoranteDTO>>();
                if (validator is not null && rist is not null)
                {
                    var ristValid = validator.Validate(rist);
                    if(!ristValid.IsValid)
                        return Results.ValidationProblem(ristValid.ToDictionary(),
                            statusCode: (int)HttpStatusCode.UnprocessableEntity);
                }
                return await next(context);
            });     

            ristorante.MapGet("/{ristoranteId}", async (RistoranteDbContext db, int ristoranteId) =>
            {
                Ristorante? ristorante = await db.Ristorantes.FindAsync(ristoranteId);
                if(ristorante is null) return Results.NotFound();
                return Results.Ok(new RistoranteDTO(ristorante));
            });

            ristorante.MapPut("/{ristoranteId}", async(RistoranteDbContext db, int ristoranteId, RistoranteDTO ristoranteDTO) =>
            {
                //var validatorRistorante = await validator.ValidateAsync(ristoranteDTO);
                //if (!validatorRistorante.IsValid)
                //    return Results.ValidationProblem(validatorRistorante.ToDictionary(),
                //        statusCode: (int)HttpStatusCode.UnprocessableEntity);
                Ristorante? ristorante = await db.Ristorantes.FindAsync(ristoranteId);
                if (ristorante is null) return Results.NotFound();
                ristorante.Città = ristoranteDTO.Città;
                ristorante.Nome = ristoranteDTO.Nome;
                await db.SaveChangesAsync();
                return Results.Ok(new RistoranteDTO(ristorante));
            }).AddEndpointFilter(async(context, next) =>
            {
                RistoranteDTO? rist = context.Arguments.FirstOrDefault(r => r.GetType().Equals(typeof(RistoranteDTO))) as RistoranteDTO;
                IValidator<RistoranteDTO> validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<RistoranteDTO>>();
                if(rist is not null &&  validator is not null)
                {
                    var validatorRistorante = await validator.ValidateAsync(rist);
                    if (!validatorRistorante.IsValid)
                        return Results.ValidationProblem(validatorRistorante.ToDictionary(),
                            statusCode: (int)HttpStatusCode.UnprocessableEntity);
                }
                return await next(context);
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
