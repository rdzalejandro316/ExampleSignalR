using Chat.Models;
using System.Threading.Tasks;

namespace Chat.Hubs.Interfaces
{
    public interface Ichat
    {
        Task EnviarMensaje(Mensaje mensaje);
        Task RecibirMensaje(Mensaje mensaje);
        Task CounterChat();
    }
}
