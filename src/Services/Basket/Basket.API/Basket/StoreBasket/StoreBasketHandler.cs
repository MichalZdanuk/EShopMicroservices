﻿namespace Basket.API.Basket.StoreBasket;

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

internal class StoreBasketCommandHandler(IBasketRepository repository)
	: ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
	public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
	{
		ShoppingCart cart = command.Cart;

		await repository.StoreBasket(command.Cart, cancellationToken);

		return new StoreBasketResult(command.Cart.UserName);
	}
}
