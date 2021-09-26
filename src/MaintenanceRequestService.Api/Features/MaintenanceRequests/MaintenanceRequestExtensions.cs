using MaintenanceRequestService.Api.Models;

namespace MaintenanceRequestService.Api.Features
{
    public static class MaintenanceRequestExtensions
    {
        public static MaintenanceRequestDto ToDto(this MaintenanceRequest maintenanceRequest)
        {
            return new()
            {
                MaintenanceRequestId = maintenanceRequest.MaintenanceRequestId,
                Created = maintenanceRequest.Created,
                Address = maintenanceRequest.Address,
                Phone = maintenanceRequest.Phone,
                Description = maintenanceRequest.Description,
                UnattendedUnitEntryAllowed = maintenanceRequest.UnattendedUnitEntryAllowed,
                ReceivedByName = maintenanceRequest.ReceivedByName,
                ReceivedDate = maintenanceRequest.ReceivedDate,
                WorkDetails = maintenanceRequest.WorkDetails,
                WorkStarted = maintenanceRequest.WorkStarted,
                WorkCompleted = maintenanceRequest.WorkCompleted,
                WorkCompletedByName = maintenanceRequest.WorkCompletedByName,
                UnitEntered = maintenanceRequest.UnitEntered
            };
        }
    }
}
