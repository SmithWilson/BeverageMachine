using System;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Update
{
  public class UpdateDrinkCommand
    : IRequest<UpdateDrinkResult>
  {
    public UpdateDrinkCommand(Entities.Models.Drink drink)
    {
      Drink = drink ?? throw new ArgumentNullException(nameof(drink));
    }

    public Entities.Models.Drink Drink { get; }
  }
}
