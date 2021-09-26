using MaintenanceRequestService.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace MaintenanceRequestService.Api.Core
{

    public class OrchestrationHandler : IOrchestrationHandler
    {
        private readonly IMediator _mediator;
        private readonly DbContext _context;

        public OrchestrationHandler(IMediator mediator, DbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        private Subject<INotification> _messages = new Subject<INotification>();

        public async Task Publish(IAggregateRoot aggregateRoot, IEvent @event)
        {
            var type = aggregateRoot.GetType();

            var storedEvent = new StoredEvent
            {
                StoredEventId = Guid.NewGuid(),
                Aggregate = aggregateRoot.GetType().Name,
                AggregateDotNetType = aggregateRoot.GetType().AssemblyQualifiedName,
                Data = SerializeObject(@event),
                StreamId = (Guid)type.GetProperty($"{type.Name}Id").GetValue(aggregateRoot, null),
                DotNetType = @event.GetType().AssemblyQualifiedName,
                Type = @event.GetType().Name,
                CreatedOn = @event.Created,
                CorrelationId = new Guid()
            };

            _context.Set<StoredEvent>().Add(storedEvent);

            await _context.SaveChangesAsync(default);

            _messages.OnNext(@event);

            await _mediator.Publish(@event);
        }

        public async Task Publish(INotification @event)
        {
            _context.Set<StoredEvent>().Add(new StoredEvent
            {
                Data = SerializeObject(@event),
                DotNetType = @event.GetType().AssemblyQualifiedName,
                Type = @event.GetType().Name,
                CreatedOn = DateTime.UtcNow
            });

            await _context.SaveChangesAsync(default);

            _messages.OnNext(@event);

            await _mediator.Publish(@event);
        }

        public async Task<T> Handle<T>(INotification startWith, Func<TaskCompletionSource<T>, Action<INotification>> onNextFactory)
        {
            var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);

            _messages.Subscribe(onNextFactory(tcs));

            await Publish(startWith);

            return await tcs.Task;
        }
    }
}
