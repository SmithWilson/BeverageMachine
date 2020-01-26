using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeverageMachine.Controllers.Params;
using BeverageMachine.Cqrs.Coins.Commands.Update;
using BeverageMachine.Cqrs.Coins.Queries.Get;
using BeverageMachine.Entities.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BeverageMachine.Controllers
{
  [ApiController]
  [Route("api/machine")]
  public class MachineController : ControllerBase
  {
    [HttpGet("{accessCode}")]
    public async Task<IActionResult> CheckAccessCode(
      [FromRoute] string accessCode)
    {
      if (!string.IsNullOrWhiteSpace(accessCode) && accessCode == AccessCodes.access_codes)
      {
        return Ok(true);
      }

      return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Surrender(
      [FromServices] IMediator mediator,
      [FromBody] SurrenderDto surrender)
    {
      GetCoinsResponse resultQuery = await mediator.Send(new GetCoinsQuery());
      var coins = new List<Coins>(resultQuery.Coins).OrderByDescending(x => x.Par).ToList();

      int index = 0;
      while (surrender.Surrender != 0)
      {
        if (index > coins.Count - 1)
        {
          break;
        }

        if (coins[index].Count > 0 && surrender.Surrender >= coins[index].Par)
        {
          surrender.Surrender -= coins[index].Par;
          coins[index].Count -= 1;
        }
        else
        {
          index++;
        }
      }

      foreach (var coin in coins)
      {
        var command = new UpdateCoinCommand(coin);
        await mediator.Send(command);
      }

      return Ok(surrender);
    }
  }
}
