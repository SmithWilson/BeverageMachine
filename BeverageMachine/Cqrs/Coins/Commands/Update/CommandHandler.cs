using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BeverageMachine.Contracts;

using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Update
{
  public class CommandHandler
    : IRequestHandler<UpdateCoinCommand, UpdateCoinResult>
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

    public async Task<UpdateCoinResult> Handle(
      UpdateCoinCommand request,
      CancellationToken cancellationToken)
    {
      var entity = await _provider.GetAsync(x => x.Id == request.Coin.Id);

      entity.UpdateFromSource(request.Coin);
      await _provider.SaveAsync();

      return new UpdateCoinResult(entity);
    }
  }
}
