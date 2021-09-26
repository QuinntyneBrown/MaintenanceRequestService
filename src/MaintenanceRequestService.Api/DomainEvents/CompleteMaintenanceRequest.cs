using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class CompleteMaintenanceRequest: EventBase
    {
        public string WorkCompletedByName { get; set; }
        public DateTime WorkCompleted { get; set; }
    }
}
