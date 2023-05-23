using EsercizioRistorante.ModelDTO;
using FluentValidation;

namespace EsercizioRistorante.Validators
{
    public class RistoranteDTOValidator : AbstractValidator<RistoranteDTO>
    {
        public RistoranteDTOValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20).Must(ControlloNome);
        }

        private bool ControlloNome(string nome)
        {
            List<string> nomiGiusti = new List<string>() { "giorgio", "umberto" };
            foreach (var item in nomiGiusti)
            {
                if (item == nome)
                    return true;
            }
            return false;
        }
    }
}
