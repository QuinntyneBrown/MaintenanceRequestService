using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Models;
using System;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class CreateMaintenanceRequest : IEvent
    {
        public Guid MaintenanceRequestId { get; set; }
        public DateTime Created { get; set; }
        public string RequestByName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }

    }
}
