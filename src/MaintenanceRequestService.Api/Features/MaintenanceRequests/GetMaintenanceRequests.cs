using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceRequestService.Api.Features
{
    public class GetMaintenanceRequests
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<MaintenanceRequestDto> MaintenanceRequests { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IMaintenanceRequestServiceDbContext _context;
        
            public Handler(IMaintenanceRequestServiceDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    MaintenanceRequests = await _context.MaintenanceRequests.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
