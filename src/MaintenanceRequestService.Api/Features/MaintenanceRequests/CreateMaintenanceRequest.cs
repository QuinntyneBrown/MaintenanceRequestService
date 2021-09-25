using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MaintenanceRequestService.Api.Models;
using MaintenanceRequestService.Api.Core;
using MaintenanceRequestService.Api.Interfaces;

namespace MaintenanceRequestService.Api.Features
{
    public class CreateMaintenanceRequest
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.MaintenanceRequest).NotNull();
                RuleFor(request => request.MaintenanceRequest).SetValidator(new MaintenanceRequestValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public MaintenanceRequestDto MaintenanceRequest { get; set; }
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
                var maintenanceRequest = new MaintenanceRequest();
                
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
