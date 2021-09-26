using MaintenanceRequestService.Api.Models;
using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class StartMaintenanceRequest: EventBase
    {
        public UnitEntered UnitEntered { get; set; }
        public DateTime WorkStarted { get; set; }
    }
}
