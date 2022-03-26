using Mapster;
using MediatR;
using WebBotCQRS.Models;
using WebBotCore.WebSite.FilmWeb.Search;
using WebBotCQRS.Services;

namespace WebBotCQRS.Queries.WebFilm
{
    public class SearchGamesRequest : IRequest<SearchRowViewModel[]>
    {
        public string GameName { get; }

        public SearchGamesRequest(string gameName)
        {
            GameName = gameName;
        }
    }

    public class SearchGamesRequestHandler : IRequestHandler<SearchGamesRequest, SearchRowViewModel[]>
    {
        private readonly IWebResponseService webResponseService;

        public SearchGamesRequestHandler(IWebResponseService webResponseService)
        {
            this.webResponseService = webResponseService;
        }

        public async Task<SearchRowViewModel[]> Handle(SearchGamesRequest request, CancellationToken cancellationToken)
        {
            var filmSearch = new GamesSearch(request.GameName, webResponseService.GetHttpClient());
            await filmSearch.DownloadAsync();

            var searchRows = filmSearch.SearchRows;

            return searchRows.Adapt<SearchRowViewModel[]>();
        }
    }
}
