using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BeverageMachine.Contracts;

using MediatR;

namespace BeverageMachine.Cqrs.Coins.Commands.Remove
{
  public class CommandHandler
    : IRequestHandler<RemoveCoinCommand, RemoveCoinResult>
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

    public async Task<RemoveCoinResult> Handle(
      RemoveCoinCommand request,
      CancellationToken cancellationToken)
    {
      var entity = await _provider.GetAsync(x => x.Id == request.Id);
      if (entity != null)
      {
        _provider.Remove(entity);
        await _provider.SaveAsync();
      }

      return new RemoveCoinResult();
    }
  }
}
