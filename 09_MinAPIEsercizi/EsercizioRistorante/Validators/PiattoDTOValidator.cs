using EsercizioRistorante.ModelDTO;
using FluentValidation;

namespace EsercizioRistorante.Validators
{
    public class PiattoDTOValidator : AbstractValidator<PiattoDTO>
    {
        public PiattoDTOValidator() 
        {
            RuleFor(x => x.Costo).GreaterThanOrEqualTo(5).LessThanOrEqualTo(50);
        }
    }
}
