using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeverageMachine.Entities.Dtos;
using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Update
{
  public class UpdateCoinCommand
    : IRequest<UpdateCoinResult>
  {
    public UpdateCoinCommand(Entities.Models.Coins coin)
    {
      Coin = coin;
    }

    public Entities.Models.Coins Coin { get; }
  }
}
