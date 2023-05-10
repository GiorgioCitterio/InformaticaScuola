using EsercizioMinApiFilm.ModelDTO;
using FluentValidation;

namespace EsercizioMinApiFilm.Validator
{
    public class FilmDTOValidator : AbstractValidator<FilmDTO>
    {
        public FilmDTOValidator() 
        {
            RuleFor(x => x.Durata).NotEmpty().GreaterThan(50).LessThan(130);
        }
    }
}
