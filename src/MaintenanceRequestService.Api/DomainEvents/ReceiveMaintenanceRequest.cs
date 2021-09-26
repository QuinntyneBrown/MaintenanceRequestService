using MaintenanceRequestService.Api.Core;
using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class ReceiveMaintenanceRequest: IEvent
    {
        public string ReceivedByName { get; set; }
        public DateTime Created { get; set; }
    }
}
