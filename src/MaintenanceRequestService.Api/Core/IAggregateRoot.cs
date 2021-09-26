using System.Collections.Generic;

namespace MaintenanceRequestService.Api.Core
{
    public interface IAggregateRoot
    {
        AggregateRoot Apply(IEvent @event);
    }
}