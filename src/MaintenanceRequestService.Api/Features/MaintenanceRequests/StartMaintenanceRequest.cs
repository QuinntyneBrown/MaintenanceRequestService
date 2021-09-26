using MaintenanceRequestService.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenanceRequestService.Api.Features
{
    public class StartMaintenanceRequest
    {
        public class Request : DomainEvents.StartMaintenanceRequest, IRequest<Response>
        {
            public Guid MaitenanceRequestId { get; set; }
        }

        public class Response
        {
            public MaintenanceRequestDto MaintenanceRequest { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IMaintenanceRequestServiceDbContext _context;

            public Handler(IMaintenanceRequestServiceDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var maintenanceRequest = await _context.MaintenanceRequests.SingleAsync(x => x.MaintenanceRequestId == request.MaitenanceRequestId);

                maintenanceRequest.Apply(request);

                await _context.SaveChangesAsync(default);

                return new()
                {
                    MaintenanceRequest = maintenanceRequest.ToDto()
                };
            }
        }
    }
}
