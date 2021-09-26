using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Core.Models;
using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class CreateMaintenanceRequest : IEvent
    {
        public Guid MaintenanceRequestId { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; }
        public string RequestByName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }

    }
}
