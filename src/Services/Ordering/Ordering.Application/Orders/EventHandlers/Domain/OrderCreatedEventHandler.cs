using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
	: INotificationHandler<OrderCreatedEvent>
{
	public Task Handle(OrderCreatedEvent @event, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain Event handled: {domainEvent}", @event.GetType().Name);
		return Task.CompletedTask;
	}
}
