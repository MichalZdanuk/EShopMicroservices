namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
{
	public StoreBasketValidator()
	{
		RuleFor(x => x.Cart).NotEmpty().WithMessage("Cart can not be null");
		RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
	}
}

internal class StoreBasketCommandHandler
	: ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
	public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
	{
		ShoppingCart cart = command.Cart;

		// TODO: store basket in DB (use Marten upsert)
		// TODO: update cache

		return new StoreBasketResult("abc");
	}
}
