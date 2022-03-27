using FluentValidation;
using WebBotCQRS.Queries.WebFilm;

namespace WebBotCQRS.Validation.WebFilm
{
    public class FilmRequestValidator : AbstractValidator<FilmRequest>
    {
        public FilmRequestValidator()
        {
            RuleFor(f => f.PartUri)
                .MinimumLength(3);
        }
    }
}
