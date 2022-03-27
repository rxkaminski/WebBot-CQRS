using Mapster;
using MediatR;
using WebBotCQRS.Models;
using WebBotCore.WebSite.FilmWeb.Search.Details;
using WebBotCQRS.Services;

namespace WebBotCQRS.Queries.WebFilm
{
    public class SearchFilmsRequest : IRequest<SearchRowViewModel[]>
    {
        public string Title { get; }

        public SearchFilmsRequest(string title)
        {
            Title = title;
        }
    }

    public class SearchFilmsRequestHandler : IRequestHandler<SearchFilmsRequest, SearchRowViewModel[]>
    {
        private readonly IWebResponseService webResponseService;

        public SearchFilmsRequestHandler(IWebResponseService webResponseService)
        {
            this.webResponseService = webResponseService;
        }

        public async Task<SearchRowViewModel[]> Handle(SearchFilmsRequest request, CancellationToken cancellationToken)
        {
            var filmSearch = new FilmsSearch(request.Title, webResponseService.GetHttpClient());
            await filmSearch.DownloadAsync();

            var searchRows = filmSearch.SearchRows;

            return searchRows.Adapt<SearchRowViewModel[]>();
        }
    }
}
