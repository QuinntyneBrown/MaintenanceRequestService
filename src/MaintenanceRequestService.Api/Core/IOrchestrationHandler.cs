using MediatR;
using System;
using System.Threading.Tasks;

namespace MaintenanceRequestService.Api.Core
{
    public interface IOrchestrationHandler
    {
        public Task Publish(INotification message);
        public Task Publish(IAggregateRoot aggregateRoot, IEvent message);
        public Task<T> Handle<T>(INotification startWith, Func<TaskCompletionSource<T>, Action<INotification>> onNextFactory);
    }
}
