using System;

namespace BeverageMachine.Cqrs.Drink.Commands.Update
{
  public class UpdateDrinkResult
  {
    public UpdateDrinkResult(Entities.Models.Drink drink)
    {
      Drink = drink ?? throw new ArgumentNullException(nameof(drink));
    }

    public Entities.Models.Drink Drink { get; }
  }
}
