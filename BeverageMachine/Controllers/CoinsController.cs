using System.Threading.Tasks;

using BeverageMachine.Cqrs.Coins.Commands.Add;
using BeverageMachine.Cqrs.Coins.Commands.Remove;
using BeverageMachine.Cqrs.Coins.Commands.Update;
using BeverageMachine.Cqrs.Coins.Queries.Get;
using BeverageMachine.Entities.Dtos;
using BeverageMachine.Entities.Models;
using BeverageMachine.Filters;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BeverageMachine.Controllers
{
  [ApiController]
  [Route("api/coin")]
  [ModelStateValidationFilter]
  public class CoinsController : ControllerBase
  {
    [HttpGet]
    public async Task<JsonResult> Get(
      [FromServices] IMediator mediator)
    {
      var query = new GetCoinsQuery();
      GetCoinsResponse data = await mediator.Send(query);

      return new JsonResult(data.Coins);
    }

    [HttpPost]
    public async Task<JsonResult> Add(
      [FromServices] IMediator mediator,
      [FromBody] CoinDto coin)
    {
      if (coin is null)
      {
        throw new System.ArgumentNullException(nameof(coin));
      }

      var command = new AddCoinCommand(coin);
      AddCoinResult data = await mediator.Send(command);

      return new JsonResult(data.Coin);
    }

    [HttpPut]
    public async Task<JsonResult> Update(
      [FromServices] IMediator mediator,
      [FromBody] Coins coin)
    {
      if (coin is null)
      {
        throw new System.ArgumentNullException(nameof(coin));
      }

      var command = new UpdateCoinCommand(coin);
      UpdateCoinResult data = await mediator.Send(command);

      return new JsonResult(data.Coin);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(
      [FromServices] IMediator mediator,
      [FromRoute] int id)
    {
      var command = new RemoveCoinCommand(id);
      await mediator.Send(command);

      return Ok();
    }
  }
}
