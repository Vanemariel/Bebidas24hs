using Bebidas24hs.Client.Services.Interface;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bebidas24hs.Client.Services
{
    public class HttpService : IHttpService //es una clase que le genero metodos como el get
    {
        private readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<date>> Get<date>(string url)
        {
            var respuestaHttp = await http.GetAsync(url);
            if (respuestaHttp.IsSuccessStatusCode)
            {
                var respuesta = await DeserializarRespuesta<date>(respuestaHttp);
                return new HttpRespuesta<date>(respuesta,
                                            false,
                                            respuestaHttp);
            }
            else
            {
                return new HttpRespuesta<date>(default,
                                            true,
                                            respuestaHttp);
            }
        }

        public async Task<HttpRespuesta<object>> Post<date>(string url, date enviar)
        {
            try
            {
                var enviarJSON = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJSON,
                                                      Encoding.UTF8,
                                                      "application/json");
                var respuestaHTTP = await http.PostAsync(url, enviarContent);

                return new HttpRespuesta<object>(null,
                                                 !respuestaHTTP.IsSuccessStatusCode,
                                                 respuestaHTTP);
            }
            catch (System.Exception e) { throw; }
        }

        public async Task<HttpRespuesta<object>> Put<date>(string url, date enviar)
        {
            try
            {
                var enviarJSON = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJSON,
                                                      Encoding.UTF8,
                                                      "application/json");
                var respuestaHTTP = await http.PutAsync(url, enviarContent);

                return new HttpRespuesta<object>(null,
                                                 !respuestaHTTP.IsSuccessStatusCode,
                                                 respuestaHTTP);
            }
            catch (System.Exception e) { throw; }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var respuestaHTTP = await http.DeleteAsync(url);
            return new HttpRespuesta<object>(null,
                                             !respuestaHTTP.IsSuccessStatusCode,
                                              respuestaHTTP);
        }

        private async Task<dato> DeserializarRespuesta<dato>(HttpResponseMessage httprespuesta)
        {
            var RepuestaString = await httprespuesta.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<dato>(RepuestaString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}