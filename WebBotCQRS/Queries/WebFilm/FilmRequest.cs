using Mapster;
using MediatR;
using WebBotCQRS.Models;
using WebBotCore.WebSite.FilmWeb.Film;
using WebBotCQRS.Services;

namespace WebBotCQRS.Queries.WebFilm
{
    public class FilmRequest : IRequest<FilmDetailsViewModel>
    {
        public string PartUri { get; }

        public FilmRequest(string partUri)
        {
            PartUri = partUri;
        }
    }

    public class FilmRequestHandler : IRequestHandler<FilmRequest, FilmDetailsViewModel>
    {
        private readonly IWebResponseService webResponseService;

        public FilmRequestHandler(IWebResponseService webResponseService)
        {
            this.webResponseService = webResponseService;
        }

        public async Task<FilmDetailsViewModel> Handle(FilmRequest request, CancellationToken cancellationToken)
        {
            var film = new FilmDetails(request.PartUri, webResponseService.GetHttpClient());
            await film.DownloadAsync();

            var filmDetails = film.Details;

            return filmDetails.Adapt<FilmDetailsViewModel>();
        }
    }
}
