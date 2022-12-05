"use strict";

var conexion = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

conexion.on("recibirMensaje", function (data) {

    var li = document.createElement("li");
    console.log("data:",data);

    li.textContent = data.usuario + " - " + data.contenido;
    document.getElementById("lstMensajes").appendChild(li);
});


conexion.start().then(
    function () {
        //var li = document.createElement("li");
        //li.textContent = "Bienvenido al chat";
        //document.getElementById("lstMensajes").appendChild(li);

        conexion.stream("Counter").subscribe(
            {
                next: (item) => { document.getElementById("lblDuracion").innerHTML = item },
                complete: (item) => { document.getElementById("lblDuracion").innerHTML = "Se acabó el tiempo" },
                error: (error) => { console.error(error) },
            });

    }
).catch(function (error) {
    console.error(error);
});


document.getElementById("btnenviar").addEventListener("click", function (event) {
    var usuario = document.getElementById("txtusuario").value;
    var mensaje = document.getElementById("txtmensaje").value;

    var data = {
        usuario: usuario,
        contenido: mensaje,
    }

    conexion.invoke("EnviarMensaje", data)
        .catch(
            function (error) {
                console.error(error);
            }
        );
    event.preventDefault();
});