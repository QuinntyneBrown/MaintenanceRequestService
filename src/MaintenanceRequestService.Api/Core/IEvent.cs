using MediatR;
using System;

namespace MaintenanceRequestService.Api.Core
{
    public interface IEvent: INotification
    {
        DateTime Created { get; }
    }
}