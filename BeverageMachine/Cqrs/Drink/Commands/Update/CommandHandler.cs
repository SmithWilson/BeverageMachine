using System.Threading;
using System.Threading.Tasks;

using BeverageMachine.Contracts;
using BeverageMachine.Cqrs.Drink.Queries.GetById;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Update
{
  public class CommandHandler
    : IRequestHandler<UpdateDrinkCommand, UpdateDrinkResult>
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

    public async Task<UpdateDrinkResult> Handle(UpdateDrinkCommand request, CancellationToken cancellationToken)
    {
      GetDrinkByIdResponse entity = await _mediator.Send(new GetDrinkByIdQuery(request.Drink.Id));
      entity.Drink.UpdateFromSource(request.Drink);

      await _provider.SaveAsync();

      return new UpdateDrinkResult(entity.Drink);
    }
  }
}
