using MaintenanceRequestService.Api.Core.Models;
using MaintenanceRequestService.Api.Models;
using Xunit;

namespace MaintenanceRequestService.UnitTests
{

    public class MaintenanceRequestTests
    {
        [Fact]
        public void CreateMaintenanceRequest()
        {

            var aggregate = new MaintenanceRequest(new Api.DomainEvents.CreateMaintenanceRequest { 
            
                Address = Address.Create("default", "default", "default", "default").Value
            });

            Assert.NotEqual(default, aggregate.MaintenanceRequestId);

        }
    }
}
