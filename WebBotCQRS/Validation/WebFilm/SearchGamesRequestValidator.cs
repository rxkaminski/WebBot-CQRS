using FluentValidation;
using WebBotCQRS.Queries.WebFilm;

namespace WebBotCQRS.Validation.WebFilm
{
    public class SearchGamesRequestValidator : AbstractValidator<SearchGamesRequest>
    {
        public SearchGamesRequestValidator()
        {
            RuleFor(f => f.GameName)
                .MinimumLength(3);
        }
    }
}
