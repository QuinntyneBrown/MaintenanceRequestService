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
    public class RemoveStoredEvent
    {
        public class Request: IRequest<Response>
        {
            public Guid StoredEventId { get; set; }
        }

        public class Response: ResponseBase
        {
            public StoredEventDto StoredEvent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IMaintenanceRequestServiceDbContext _context;
        
            public Handler(IMaintenanceRequestServiceDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var storedEvent = await _context.StoredEvents.SingleAsync(x => x.StoredEventId == request.StoredEventId);
                
                _context.StoredEvents.Remove(storedEvent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    StoredEvent = storedEvent.ToDto()
                };
            }
            
        }
    }
}
