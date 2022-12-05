using Chat.Hubs.Interfaces;
using Chat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class ChatHub : Hub<Ichat>
    {
        //public async Task EnviarMensaje(string usuario, string mensaje)
        //{
        //    await Clients.All.SendAsync("recibirMensaje", usuario, mensaje);
        //}


        public async Task EnviarMensaje(Mensaje mensaje)
        {
            await Clients.All.RecibirMensaje(mensaje);
        }

        public async IAsyncEnumerable<int> Counter()
        {
            for (int i = 1; i < 1000000; i++)
            {
                yield return i;

                await Task.Delay(1000);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecibirMensaje(new Mensaje()
            {
                usuario = "HOST",
                contenido = "Bienvenido desde singalr"

            });
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }
}
