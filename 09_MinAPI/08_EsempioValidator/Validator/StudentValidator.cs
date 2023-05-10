using FluentValidation;
using _08_EsempioValidator.Model;

namespace _08_EsempioValidator.Validator
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator() 
        {
            //faccio le regole
            RuleFor(x => x.Name).NotEmpty().WithMessage("campo non vuoto").MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Age).NotEmpty().GreaterThan(18);
        }
    }
}
