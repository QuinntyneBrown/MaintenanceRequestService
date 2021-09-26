using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequestService.Api.DomainEvents
{
    public class UpdateMaintenanceRequestWorkDetails: EventBase
    {
        public string WorkDetails { get; set; }
    }
}
