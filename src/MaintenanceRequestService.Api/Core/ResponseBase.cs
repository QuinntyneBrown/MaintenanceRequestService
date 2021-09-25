using System.Collections.Generic;

namespace MaintenanceRequestService.Api.Core
{
    public class ResponseBase
    {
        public List<string> ValidationErrors { get; set; }
    }
}
