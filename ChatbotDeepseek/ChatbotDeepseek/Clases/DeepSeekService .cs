using ChatbotDeepseek.Interfaz;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace ChatbotDeepseek.Clases
{
    // Clase que implementa el servicio y la lógica de comunicación con la API
    public class DeepSeekService : IDeepSeekService
    {
        // URL de la API DeepSeek, cargada desde Web.config
        private readonly string _apiUrl;
        // Nombre del modelo que se usará para las solicitudes
        private readonly string _modelo;

        // Constructor: carga valores desde el archivo Web.config
        public DeepSeekService()
        {
            _apiUrl = ConfigurationManager.AppSettings["UrlApiDeepseek"];
            _modelo = ConfigurationManager.AppSettings["ModeloDeepseek"];
        }

        // Implementación del método para enviar un mensaje al chatbot
        public RespuestaGeneral EnviarMensajeAlChatbot(string mensaje, string tokenServicio)
        {
            // Inicializa la respuesta vacía
            RespuestaGeneral respuestaGeneral = new RespuestaGeneral();

            try
            {
                // Crea el objeto de solicitud con el mensaje y el modelo
                var solicitudChatbot = new MensajeChatbot
                {
                    model = _modelo,
                    messages = new[]
                    {
                    new Mensaje { role = "user", content = mensaje } // Rol "user" envía el contenido
                }
                };

                // Serializa la solicitud a formato JSON
                var jsonSolicitud = JsonConvert.SerializeObject(solicitudChatbot);
                // Crea el cliente HTTP apuntando a la URL de DeepSeek
                var client = new RestClient(_apiUrl);
                // Prepara la solicitud POST
                var request = new RestRequest();
                request.Method = Method.Post;

                // Agrega encabezado de tipo de contenido
                request.AddHeader("Content-Type", "application/json");
                // Agrega encabezado de autorización (Bearer token)
                request.AddHeader("Authorization", $"Bearer {tokenServicio}");
                // Agrega el cuerpo JSON de la solicitud
                request.AddParameter("application/json", jsonSolicitud, ParameterType.RequestBody);

                // Ejecuta la solicitud y obtiene la respuesta
                RestResponse respuesta = client.Execute(request);

                // Si la respuesta es exitosa (200 OK)
                if (respuesta.StatusCode == HttpStatusCode.OK)
                {
                    // Deserializa la respuesta JSON en el objeto de respuesta esperada
                    respuestaGeneral = JsonConvert.DeserializeObject<RespuestaGeneral>(respuesta.Content);
                }
                else
                {
                    // En caso de error, marca la respuesta como fallida y guarda el contenido del error
                    respuestaGeneral.respuesta = false;
                    respuestaGeneral.mensaje = respuesta.Content;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: guarda el mensaje de error
                respuestaGeneral.respuesta = false;
                respuestaGeneral.mensaje = ex.Message;
            }

            // Devuelve la respuesta final
            return respuestaGeneral;
        }


    }
}