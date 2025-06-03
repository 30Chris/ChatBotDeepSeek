// scriptEnviar.js
window.onload = function () {
    const input = document.getElementById("mensaje");
    const boton = document.getElementById(window.btnEnviarClientID); // usamos variable global

    if (input && boton) {
        input.addEventListener("keypress", function (e) {
            if (e.key === "Enter") {
                e.preventDefault();
                boton.click();
            }
        });
    }
};