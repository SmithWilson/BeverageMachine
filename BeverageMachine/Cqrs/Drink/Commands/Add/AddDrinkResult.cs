using System;

namespace BeverageMachine.Cqrs.Drink.Commands.Add
{
  public class AddDrinkResult
  {
    public AddDrinkResult(Entities.Models.Drink drink)
    {
      Drink = drink ?? throw new ArgumentNullException(nameof(drink));
    }

    public Entities.Models.Drink Drink { get; }
  }
}
