using ChatbotDeepseek.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotDeepseek.Interfaz
{
    // Interfaz que define el contrato del servicio
    internal interface IDeepSeekService
    {
        // Método para enviar un mensaje al chatbot DeepSeek
        RespuestaGeneral EnviarMensajeAlChatbot(string mensaje, string tokenServicio);

    }
}
