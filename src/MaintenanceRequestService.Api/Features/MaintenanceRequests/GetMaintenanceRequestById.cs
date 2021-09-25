using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceRequestService.Api.Features
{
    public class GetMaintenanceRequestById
    {
        public class Request: IRequest<Response>
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
                return new () {
                    MaintenanceRequest = (await _context.MaintenanceRequests.SingleOrDefaultAsync(x => x.MaintenanceRequestId == request.MaintenanceRequestId)).ToDto()
                };
            }
            
        }
    }
}
