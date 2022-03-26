using MediatR;
using WebBotCore.Translate;
using WebBotCore.WebSite.Converters;
using WebBotCQRS.Services;

namespace WebBotCQRS.Queries.Converters
{
    public class JsonToXmlConvertRequest : IRequest<string>
    {
        public string JsonEndPoint { get; }
        public JsonToXmlConvertRequest(string jsonEndPoint)
        {
            JsonEndPoint = jsonEndPoint;
        }
    }

    public class JsonToXmlConvertRequestHandler : IRequestHandler<JsonToXmlConvertRequest, string>
    {
        private readonly IWebResponseService webResponseService;

        public JsonToXmlConvertRequestHandler(IWebResponseService webResponseService)
        {
            this.webResponseService = webResponseService;
        }

        public async Task<string> Handle(JsonToXmlConvertRequest request, CancellationToken cancellationToken)
        {
            var jsonToXmlConvert = new JsonToXmlConvert(request.JsonEndPoint, webResponseService.GetHttpClient(new JsonToXmlTranslateResponse()));
            await jsonToXmlConvert.DownloadAsync();

            return jsonToXmlConvert?.Xml?.OuterXml ?? string.Empty;
        }
    }
}
