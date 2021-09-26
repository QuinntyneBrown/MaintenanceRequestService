using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.DomainEvents;
using System;

namespace MaintenanceRequestService.Api.Models
{
    public class MaintenanceRequest: AggregateRoot
    {
        public Guid MaintenanceRequestId { get; private set; }
        public string RequestByName { get; private set; }
        public DateTime Created { get; set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public string Description { get; private set; }
        public bool UnattendedUnitEntryAllowed { get; private set; }
        public string ReceivedByName { get; private set; }
        public DateTime ReceivedDate { get; private set; }
        public string WorkDetails { get; set; }
        public DateTime WorkStarted { get; set; }
        public DateTime WorkCompleted { get; set; }
        public string WorkCompletedByName { get; set; }
        public UnitEntered? UnitEntered { get; set; }

        public MaintenanceRequest(CreateMaintenanceRequest @event)
        {
            Apply(@event);
        }

        private MaintenanceRequest()
        {

        }

        protected override void EnsureValidState()
        {
            
        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateMaintenanceRequest @event)
        {
            MaintenanceRequestId = @event.MaintenanceRequestId;
            Created = @event.Created;
            RequestByName = @event.RequestByName;
            Address = @event.Address;
            Phone = @event.Phone;
            Description = @event.Description;
            UnattendedUnitEntryAllowed = @event.UnattendedUnitEntryAllowed;
        }

        private void When(ReceiveMaintenanceRequest @event)
        {
            ReceivedByName = @event.ReceivedByName;
            ReceivedDate = @event.Created;
        }

        private void When(UpdateMaintenanceRequestWorkDetails @event)
        {
            WorkDetails = @event.WorkDetails;
        }

        private void When(StartMaintenanceRequest @event)
        {
            UnitEntered = @event.UnitEntered;
            WorkStarted = @event.WorkStarted;
        }

        private void When(CompleteMaintenanceRequest @event)
        {
            WorkCompletedByName = @event.WorkCompletedByName;
            WorkCompleted = @event.WorkCompleted;
        }
    }
}
