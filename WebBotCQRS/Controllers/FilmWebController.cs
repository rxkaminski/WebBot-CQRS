using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBotCQRS.Queries.WebFilm;

namespace WebBotCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmWebController : MainController
    {
        public FilmWebController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Find game
        /// </summary>
        /// <param name="gameName">game name</param>
        /// <returns>list of games</returns>
        [HttpGet("search/games/{gameName}")]
        public async Task<IActionResult> SearchGames(string gameName)
        {
            var result = await mediator.Send(new SearchGamesRequest(gameName));

            return new JsonResult(result);
        }

        /// <summary>
        /// Find films
        /// </summary>
        /// <param name="title">title</param>
        /// <returns>list of films</returns>
        [HttpGet("search/films/{title}")]
        public async Task<IActionResult> SearchFilms(string title)
        {
            var result = await mediator.Send(new SearchFilmsRequest(title));

            return new JsonResult(result);
        }

        /// <summary>
        /// Get film details
        /// </summary>
        /// <param name="partUri">f.e. "Rambo%2BII-1985-997"</param>
        /// <returns>films details</returns>
        [HttpGet("film/{partUri}")]
        public async Task<IActionResult> Film(string partUri)
        {
            var result = await mediator.Send(new FilmRequest(partUri));

            return new JsonResult(result);
        }
    }
}
