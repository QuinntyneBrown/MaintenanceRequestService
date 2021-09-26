using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Models;
using System;

namespace MaintenanceRequestService.Api.Features
{
    public class MaintenanceRequestDto
    {
        public Guid MaintenanceRequestId { get; set; }
        public DateTime Created { get; set; }
        public string RequestByName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool UnattendedUnitEntryAllowed { get; set; }
        public string ReceivedByName { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string WorkDetails { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkCompleted { get; set; }
        public string WorkCompletedByName { get; set; }
        public UnitEntered? UnitEntered { get; set; }
    }
}
