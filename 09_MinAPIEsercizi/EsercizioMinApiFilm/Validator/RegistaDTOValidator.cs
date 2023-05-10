using EsercizioMinApiFilm.ModelDTO;
using FluentValidation;

namespace EsercizioMinApiFilm.Validator
{
    public class RegistaDTOValidator : AbstractValidator<RegistaDTO>
    {
        public RegistaDTOValidator() 
        {
            RuleFor(x => x.Nome).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Cognome).NotEmpty().MinimumLength(3).MaximumLength(20);
        }
    }
}
