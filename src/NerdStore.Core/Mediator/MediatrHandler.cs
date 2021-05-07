﻿using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Mediator
{
    public class MediatrHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }
    }
}
