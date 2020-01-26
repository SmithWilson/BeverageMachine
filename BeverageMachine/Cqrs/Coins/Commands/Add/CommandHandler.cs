using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BeverageMachine.Contracts;

using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Add
{
  public class CommandHandler
    : IRequestHandler<AddCoinCommand, AddCoinResult>
  {
    private readonly IDataProvider<Entities.Models.Coins> _provider;
    private readonly IMapper _mapper;

    public CommandHandler(
      IDataProvider<Entities.Models.Coins> provider,
      IMapper mapper)
    {
      _provider = provider;
      _mapper = mapper;
    }

    public async Task<AddCoinResult> Handle(
      AddCoinCommand request,
      CancellationToken cancellationToken)
    {
      var coinEntity = _mapper.Map<Entities.Models.Coins>(request.CoinDto);

      _provider.Add(coinEntity);
      await _provider.SaveAsync();

      return new AddCoinResult(coinEntity);
    }
  }
}
