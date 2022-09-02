using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bebidas24hs.Client.Services
{
    public class HttpRespuesta<date>
    {
        public date Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpResponseMessage { get; }

        public HttpRespuesta(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public HttpRespuesta(date respuesta,
                             bool error,
                             HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

        public async Task<string> GetBody()
        {
            var resp = await httpResponseMessage.Content.ReadAsStringAsync();
            return resp;
        }

    }
}