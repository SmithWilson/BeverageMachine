using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeverageMachine.Cqrs.Coins.Queries.Get
{
  public class GetCoinsResponse
  {
    public GetCoinsResponse(IReadOnlyCollection<Entities.Models.Coins> coins)
    {
      Coins = coins ?? throw new ArgumentNullException(nameof(coins));
    }

    public IReadOnlyCollection<Entities.Models.Coins> Coins { get; set; }
  }
}
