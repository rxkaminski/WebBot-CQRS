using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebBotCQRS.Queries.Converters;

namespace WebBotCQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController : MainController
    {
        public ConverterController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Convert JSON response from jsonEndPoint to the XML format
        /// </summary>
        /// <param name="jsonEndPoint">Endpoint with http[s]://</param>
        /// <returns></returns>
        [HttpGet("jsontoxml/{jsonEndPoint}")]
        public async Task<IActionResult> JsonToXml(string jsonEndPoint)
        {
            if (string.IsNullOrWhiteSpace(jsonEndPoint))
                return new StatusCodeResult(400);

            var result = await mediator.Send(new JsonToXmlConvertRequest(jsonEndPoint));

            if (string.IsNullOrEmpty(result))
                return new StatusCodeResult(404);

            return new ContentResult()
            {
                Content = result,
                ContentType = "text/xml"
            };
        }
    }
}
