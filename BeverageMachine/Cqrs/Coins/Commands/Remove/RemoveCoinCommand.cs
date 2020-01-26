using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeverageMachine.Entities.Dtos;
using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Remove
{
  public class RemoveCoinCommand
    : IRequest<RemoveCoinResult>
  {
    public RemoveCoinCommand(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
