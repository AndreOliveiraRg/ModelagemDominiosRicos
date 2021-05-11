using System;

namespace NerdStore.Core.Messages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggreagateId)
        {
            AggregateId = aggreagateId;
        }
    }
}
