using System.Threading.Tasks;

using BeverageMachine.Cqrs.Drink.Commands.Add;
using BeverageMachine.Cqrs.Drink.Commands.Remove;
using BeverageMachine.Cqrs.Drink.Commands.Update;
using BeverageMachine.Cqrs.Drink.Queries.Get;
using BeverageMachine.Cqrs.Drink.Queries.GetById;
using BeverageMachine.Entities.Dtos;
using BeverageMachine.Entities.Models;
using BeverageMachine.Filters;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BeverageMachine.Controllers
{
  [ApiController]
  [Route("api/drink")]
  [ModelStateValidationFilter]
  public class DrinkController : ControllerBase
  {
    [HttpGet]
    public async Task<JsonResult> Get(
      [FromServices] IMediator mediator)
    {
      var query = new GetDrinkQuery();
      GetDrinkResponse data = await mediator.Send(query);

      return new JsonResult(data.Drinks);
    }

    [HttpGet("{id}")]
    public async Task<JsonResult> GetById(
      [FromServices] IMediator mediator,
      [FromQuery] int id)
    {
      var query = new GetDrinkByIdQuery(id);
      GetDrinkByIdResponse data = await mediator.Send(query);

      return new JsonResult(data.Drink);
    }

    [HttpPost]
    public async Task<JsonResult> Add(
      [FromServices] IMediator mediator,
      [FromBody] DrinkDto drinkDto)
    {
      var command = new AddDrinkCommand(drinkDto);
      AddDrinkResult data = await mediator.Send(command);

      return new JsonResult(data.Drink);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(
      [FromServices] IMediator mediator,
      [FromRoute] int id)
    {
      var command = new RemoveDrinkCommand(id);
      RemoveDrinkResult data = await mediator.Send(command);

      return Ok();
    }

    [HttpPut]
    public async Task<JsonResult> Update(
      [FromServices] IMediator mediator,
      [FromBody] Drink drink)
    {
      var command = new UpdateDrinkCommand(drink);
      UpdateDrinkResult data = await mediator.Send(command);

      return new JsonResult(data.Drink);
    }
  }
}
