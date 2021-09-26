using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenanceRequestService.Api.Features
{
    public class RemoveMaintenanceRequest
    {
        public class Request: DomainEvents.RemoveMaintenanceRequest, IRequest<Response>
        {
            public Guid MaintenanceRequestId { get; set; }
        }

        public class Response: ResponseBase
        {
            public MaintenanceRequestDto MaintenanceRequest { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IMaintenanceRequestServiceDbContext _context;

        
            public Handler(IMaintenanceRequestServiceDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == request.MaintenanceRequestId);

                maintenanceRequest.Apply(request);

                _context.MaintenanceRequests.Remove(maintenanceRequest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    MaintenanceRequest = maintenanceRequest.ToDto()
                };
            }
            
        }
    }
}
