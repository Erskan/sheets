using FluentValidation;

namespace SheetsApi.Forces
{
    public class ForceValidator : AbstractValidator<Force>
    {
        public ForceValidator()
        {
            RuleFor(force => force.Id).NotEmpty().GreaterThan(0);
            RuleFor(force => force.Name).NotEmpty();
        }
    }
}