using System;
using MaintenanceRequestService.Api.Models;

namespace MaintenanceRequestService.Api.Features
{
    public static class MaintenanceRequestExtensions
    {
        public static MaintenanceRequestDto ToDto(this MaintenanceRequest maintenanceRequest)
        {
            return new ()
            {
                MaintenanceRequestId = maintenanceRequest.MaintenanceRequestId
            };
        }
        
    }
}
