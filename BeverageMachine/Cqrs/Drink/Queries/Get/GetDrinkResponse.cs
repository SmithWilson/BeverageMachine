using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeverageMachine.Cqrs.Drink.Queries.Get
{
  public class GetDrinkResponse
  {
    public GetDrinkResponse(IReadOnlyCollection<Entities.Models.Drink> drinks)
    {
      Drinks = drinks ?? throw new ArgumentNullException(nameof(drinks));
    }

    public IReadOnlyCollection<Entities.Models.Drink> Drinks { get; set; }
  }
}
