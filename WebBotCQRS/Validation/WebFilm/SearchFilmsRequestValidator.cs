using FluentValidation;
using WebBotCQRS.Queries.WebFilm;

namespace WebBotCQRS.Validation.WebFilm
{
    public class SearchFilmsRequestValidator: AbstractValidator<SearchFilmsRequest>
    {
        public SearchFilmsRequestValidator()
        {
            RuleFor(f => f.Title)
                .MinimumLength(3);
        }
    }
}
