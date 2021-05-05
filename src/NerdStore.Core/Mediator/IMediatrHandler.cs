using System.Threading.Tasks;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}