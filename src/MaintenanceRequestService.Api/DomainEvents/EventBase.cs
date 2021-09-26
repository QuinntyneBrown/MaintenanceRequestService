using MaintenanceRequestService.Api.Core;
using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class EventBase: IEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
