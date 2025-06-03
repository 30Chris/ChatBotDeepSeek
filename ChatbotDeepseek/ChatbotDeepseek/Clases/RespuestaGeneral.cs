using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatbotDeepseek.Clases
{
    public class RespuestaGeneral
    {
        public bool respuesta { get; set; }
        public string mensaje { get; set; }
    }

    public class MensajeChatbot
    {
        public string model { get; set; }
        public Mensaje[] messages { get; set; }
    }

    public class Mensaje
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}