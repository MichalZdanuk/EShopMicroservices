using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder;
public class CreateOrderHandler
	: ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
	public Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		// create Order entity from command
		// save to db
		// return result

		throw new NotImplementedException();
	}
}
