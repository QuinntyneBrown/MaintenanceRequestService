using MaintenanceRequestService.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace MaintenanceRequestService.Api.Interfaces
{
    public interface IMaintenanceRequestServiceDbContext
    {
        DbSet<MaintenanceRequest> MaintenanceRequests { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
