using System.Threading;
using System.Threading.Tasks;

using BeverageMachine.Contracts;
using BeverageMachine.Cqrs.Drink.Queries.GetById;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Remove
{
  public class CommandHandler
    : IRequestHandler<RemoveDrinkCommand, RemoveDrinkResult>
  {
    private readonly IDataProvider<Entities.Models.Drink> _provider;
    private readonly IMediator _mediator;

    public CommandHandler(
      IDataProvider<Entities.Models.Drink> provider,
      IMediator mediator)
    {
      _provider = provider;
      _mediator = mediator;
    }

    public async Task<RemoveDrinkResult> Handle(RemoveDrinkCommand request, CancellationToken cancellationToken)
    {
      GetDrinkByIdResponse entity = await _mediator.Send(new GetDrinkByIdQuery(request.Id));
      if (entity?.Drink != null)
      {
        _provider.Remove(entity.Drink);
        await _provider.SaveAsync();
      }

      return new RemoveDrinkResult();
    }
  }
}
