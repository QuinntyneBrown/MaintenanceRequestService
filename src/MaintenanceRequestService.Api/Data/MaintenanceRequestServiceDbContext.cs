using MaintenanceRequestService.Api.Models;
using MaintenanceRequestService.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceRequestService.Api.Data
{
    public class MaintenanceRequestServiceDbContext: DbContext, IMaintenanceRequestServiceDbContext
    {
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; private set; }
        public MaintenanceRequestServiceDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaintenanceRequestServiceDbContext).Assembly);
        }
        
    }
}
