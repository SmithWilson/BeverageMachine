using System;

using BeverageMachine.Entities.Dtos;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Add
{
  public class AddDrinkCommand
    : IRequest<AddDrinkResult>
  {
    public AddDrinkCommand(DrinkDto dto)
    {
      DrinkDto = dto ?? throw new ArgumentNullException(nameof(dto));
    }

    public DrinkDto DrinkDto { get; }
  }
}
