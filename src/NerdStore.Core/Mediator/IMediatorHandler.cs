using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task EnviarComando<T>(T comando) where T : Command;
    }
}