using System.Threading.Tasks;

namespace Bebidas24hs.Client.Services.Interface
{
    public interface IHttpService
    {
        Task<HttpRespuesta<object>> Delete(string url);
        Task<HttpRespuesta<date>> Get<date>(string url);
        Task<HttpRespuesta<object>> Post<date>(string url, date enviar);
        Task<HttpRespuesta<object>> Put<date>(string url, date enviar);
    }
}