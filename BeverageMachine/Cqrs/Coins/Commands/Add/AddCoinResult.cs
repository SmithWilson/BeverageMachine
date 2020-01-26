using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeverageMachine.Cqrs.Coins.Commands.Add
{
  public class AddCoinResult
  {
    public AddCoinResult(Entities.Models.Coins coin)
    {
      Coin = coin ?? throw new ArgumentNullException(nameof(coin));
    }

    public Entities.Models.Coins Coin { get; }
  }
}
