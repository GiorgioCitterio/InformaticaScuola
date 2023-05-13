using EsercizioPreVerifica.ModelDTO;
using FluentValidation;

namespace EsercizioPreVerifica.Validators
{
    public class FilmDTOValidator : AbstractValidator<FilmDTO>
    {
        public FilmDTOValidator() 
        {
            RuleFor(x => x.Titolo).NotNull().NotEmpty().MaximumLength(2).MaximumLength(50);
            RuleFor(x => x.DataDiProduzione).LessThan(DateTime.Now);
            RuleFor(x => x.Durata).LessThan(500).GreaterThan(1);
        }
    }
}
