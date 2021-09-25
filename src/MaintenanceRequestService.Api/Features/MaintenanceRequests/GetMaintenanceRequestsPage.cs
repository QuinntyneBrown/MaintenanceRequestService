using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MaintenanceRequestService.Api.Extensions;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;
using MaintenanceRequestService.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceRequestService.Api.Features
{
    public class GetMaintenanceRequestsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<MaintenanceRequestDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IMaintenanceRequestServiceDbContext _context;
        
            public Handler(IMaintenanceRequestServiceDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from maintenanceRequest in _context.MaintenanceRequests
                    select maintenanceRequest;
                
                var length = await _context.MaintenanceRequests.CountAsync();
                
                var maintenanceRequests = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = maintenanceRequests
                };
            }
            
        }
    }
}
