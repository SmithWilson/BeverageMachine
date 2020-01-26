using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeverageMachine.Cqrs.Drink.Queries.GetById
{
  public class GetDrinkByIdResponse
  {
    public GetDrinkByIdResponse(Entities.Models.Drink drink)
    {
      Drink = drink ?? throw new ArgumentNullException(nameof(drink));
    }

    public Entities.Models.Drink Drink { get; }
  }
}
