using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Remove
{
  public class RemoveDrinkCommand
    : IRequest<RemoveDrinkResult>
  {
    public RemoveDrinkCommand(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
