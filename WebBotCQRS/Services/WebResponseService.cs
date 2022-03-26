using WebBotCore.Translate;
using WebBotCore.WebConnection;

namespace WebBotCQRS.Services
{
    public class WebResponseService : IWebResponseService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WebResponseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IWebResponse GetHttpClient(ITranslateResponse? translateResponse = null)
        {
            var httpClient = httpClientFactory.CreateClient("WebBotHttpClient");
            var webResponse = WebResponseFactory.Create(httpClient, translateResponse);

            return webResponse;
        }
    }
}
