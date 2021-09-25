using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using MaintenanceRequestService.Api.Models;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;

namespace MaintenanceRequestService.Api.Features
{
    public class RemoveMaintenanceRequest
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
                var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == request.MaintenanceRequestId);
                
                _context.MaintenanceRequests.Remove(maintenanceRequest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    MaintenanceRequest = maintenanceRequest.ToDto()
                };
            }
            
        }
    }
}
