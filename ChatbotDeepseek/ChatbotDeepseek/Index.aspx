<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ChatbotDeepseek.Index" %>

<!DOCTYPE html>

<html lang="es">

<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Site Icons -->
    <link rel="shortcut icon" href="img/deepseek.png" type="image/x-icon" />
    <!-- Estilo CSS ubicado en la carpeta /css -->
    <link rel="stylesheet" href="css/styles.css" />
    <title></title>
    <script type="text/javascript">
        window.btnEnviarClientID = "<%= btnEnviar.ClientID %>";
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="chat-container">
            <h2>¿En qué puedo ayudarte?</h2>
            <div id="chatbot">
                <asp:Literal ID="litHistorial" runat="server" />
            </div>
            <input type="text" id="mensaje" name="mensaje" autocomplete="off" placeholder="Pregunta lo que quieras..." />
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        </div>
    </form>

    <!-- Script JS ubicado en la carpeta /Scripts -->
    <script src="Scripts/script.js"></script>
</body>
</html>
