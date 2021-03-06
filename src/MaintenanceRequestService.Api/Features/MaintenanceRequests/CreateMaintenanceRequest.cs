using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MaintenanceRequestService.Api.Models;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;
using System;

namespace MaintenanceRequestService.Api.Features
{
    public class CreateMaintenanceRequest
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {

            }
        
        }

        public class Request: MaintenanceRequestService.Api.DomainEvents.CreateMaintenanceRequest, IRequest<Response> { }

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
                var maintenanceRequest = new MaintenanceRequest(request);
                
                _context.MaintenanceRequests.Add(maintenanceRequest);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    MaintenanceRequest = maintenanceRequest.ToDto()
                };
            }
            
        }
    }
}
