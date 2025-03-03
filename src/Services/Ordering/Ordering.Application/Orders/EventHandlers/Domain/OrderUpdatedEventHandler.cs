using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
	: INotificationHandler<OrderUpdatedEvent>
{
	public Task Handle(OrderUpdatedEvent @event, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain Event handled: {domainEvent}", @event.GetType().Name);
		return Task.CompletedTask;
	}
}
