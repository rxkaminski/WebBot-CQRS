using WebBotCore.Translate;
using WebBotCore.WebConnection;

namespace WebBotCQRS.Services
{
    public interface IWebResponseService
    {
        IWebResponse GetHttpClient(ITranslateResponse? translateResponse = null);
    }
}