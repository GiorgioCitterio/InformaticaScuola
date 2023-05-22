using EsercizioRistorante.ModelDTO;
using FluentValidation;

namespace EsercizioRistorante.Validators
{
    public class RistoranteDTOValidator : AbstractValidator<RistoranteDTO>
    {
        public RistoranteDTOValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
        }
    }
}
