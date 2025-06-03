using Newtonsoft.Json;
using RestSharp;
using ChatbotDeepseek.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using ChatbotDeepseek.Interfaz;
using System.Web.Services.Description;

namespace ChatbotDeepseek
{
    public partial class Index : System.Web.UI.Page
    {
        // Variable para almacenar la respuesta del chatbot
        public string RespuestaChatbot { get; set; }

        // Declaración del servicio como interfaz (mejor para pruebas e intercambios)
        private IDeepSeekService _deepSeekService;

        // Constructor de la página: se puede usar para inyectar manualmente el servicio
        public Index()
        {
            // Inyección manual: se crea una instancia del servicio
            _deepSeekService = new DeepSeekService();
        }

        protected List<string> HistorialMensajes
        {
            get
            {
                if (ViewState["Historial"] == null)
                    ViewState["Historial"] = new List<string>();
                return (List<string>)ViewState["Historial"];
            }
            set
            {
                ViewState["Historial"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HistorialMensajes = new List<string>();
            }
            MostrarHistorial();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string KeyDeepseek = ConfigurationManager.AppSettings["TokenServicioDeepseek"];

            // Capturar el mensaje del formulario
            string pregunta = Request.Form["mensaje"];
            string tokenServicio = KeyDeepseek; // Reemplaza con tu clave API

            // Enviar el mensaje al chatbot y obtener la respuesta
            var respuesta = _deepSeekService.EnviarMensajeAlChatbot(pregunta, tokenServicio);

            // Mostrar el resultado al usuario
            if (respuesta.respuesta)
            {
              
                // Guardar en historial
                HistorialMensajes.Add($"<div class='mensaje'><strong>Tú:</strong> {pregunta}</div>");
                HistorialMensajes.Add($"<div class='mensaje'><strong>Chatbot:</strong> {respuesta.mensaje}</div>");

            }
            else
            {
                // Mostrar un mensaje de error
                HistorialMensajes.Add($"<div class='mensaje'><strong>Chatbot:</strong> {respuesta.mensaje}</div>");
            }

            MostrarHistorial();

        }

        private void MostrarHistorial()
        {
            litHistorial.Text = string.Join("<br/>", HistorialMensajes);
        }
    }
}