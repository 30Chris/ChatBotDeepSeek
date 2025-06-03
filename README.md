# ChatBotDeepSeek
Este proyecto consiste en una aplicación Web desarrollada con ASP.NET Web Forms que permite la integración directa con el servicio de inteligencia artificial DeepSeek Chat mediante una API REST segura.
Su propósito es ofrecer una interfaz gráfica simple y funcional para interactuar con el chatbot, enviando preguntas o comandos y recibiendo respuestas en tiempo real.

Características principales:
Interfaz gráfica web intuitiva construida con HTML, CSS y JavaScript.

Consumo de la API de DeepSeek a través de llamadas HTTP POST utilizando la biblioteca RestSharp.

Implementación de buenas prácticas de desarrollo como:

Inyección de dependencias para desacoplar la lógica del consumo del servicio.

Lectura de parámetros configurables (como el token, modelo y URL de la API) desde Web.config.

Manejo de respuestas y errores robusto, con visualización clara de los resultados.

Diseño adaptable para extenderse a nuevas funcionalidades como historial de conversación, roles adicionales o autenticación.

Tecnologías utilizadas:
ASP.NET Web Forms (C#)

RestSharp para el consumo de APIs REST

Newtonsoft.Json para la serialización y deserialización de objetos JSON

HTML5, CSS3 y JavaScript para la capa de presentación

Estructura general:
DeepSeekService.cs: Lógica del servicio que comunica con la API.

Index.aspx / .aspx.cs: Página principal con el formulario de entrada y visualización de respuesta.

Archivos auxiliares:

style.css: Estilos personalizados.

Script.js: Scripts para manejar la interfaz del usuario.

Web.config: Configuración de claves de API, modelo y URL del servicio.
