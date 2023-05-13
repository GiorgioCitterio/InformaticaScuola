using EsercizioPreVerifica.ModelDTO;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace EsercizioPreVerifica.Validators
{
    public class RegistaDTOValidator : AbstractValidator<RegistaDTO>
    {
        public RegistaDTOValidator() 
        {
            RuleFor(x => x.Nome).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(x => x.Cognome).NotEmpty().MinimumLength(2).MaximumLength(40);
            RuleFor(x => x.Nazionalità).NotEmpty().Must(ControllaNazionalità).WithMessage("nazionalità sbagliata");
        }
        
        private bool ControllaNazionalità(string nazionalità)
        {
            List<string> nazionalitàValide = new List<string>() { "Italiana", "Francese", "Inglese", "Americana" };
            foreach (var item in nazionalitàValide)
            {
                if (nazionalità.Equals(item))
                    return true;
            }
            return false;
        }
    }
}
