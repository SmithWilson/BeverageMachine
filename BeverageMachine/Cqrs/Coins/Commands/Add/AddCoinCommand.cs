using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeverageMachine.Entities.Dtos;
using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Add
{
  public class AddCoinCommand
    : IRequest<AddCoinResult>
  {
    public AddCoinCommand(CoinDto coin)
    {
      CoinDto = coin;
    }

    public CoinDto CoinDto { get; }
  }
}
