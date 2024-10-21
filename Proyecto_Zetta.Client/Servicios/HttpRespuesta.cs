namespace Proyecto_Zetta.Client.Servicios
{
    public class HttpRespuesta<T>
    {
        public T Respuesta { get; }

        public bool Error { get; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string> ObtenerError()
        {

            if (!Error)
            {
                return "";
            }
            var statuscode = HttpResponseMessage.StatusCode;

            switch (statuscode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return HttpResponseMessage.Content.ReadAsStringAsync().ToString();

                case System.Net.HttpStatusCode.Unauthorized:
                    return "Error, no esta logueado";

                case System.Net.HttpStatusCode.Forbidden:
                    return "Error, no tiene autorizacion a ejecutar este proceso";

                case System.Net.HttpStatusCode.NotFound:
                    return "Error, direccion no encontrada";
                default:
                    return HttpResponseMessage.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
