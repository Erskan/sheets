using FluentValidation;

namespace SheetsApi.Games
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(game => game.Id).NotEmpty().GreaterThan(0);
            RuleFor(game => game.Name).NotEmpty();
        }
    }
}