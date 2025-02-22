
namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
	public DeleteBasketValidator()
	{
		RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
	}
}

internal class DeleteBasketCommandHandler(IBasketRepository repository)
	: ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
	public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
	{
		var isSuccess = await repository.DeleteBasket(command.UserName);

		return new DeleteBasketResult(isSuccess);
	}
}
