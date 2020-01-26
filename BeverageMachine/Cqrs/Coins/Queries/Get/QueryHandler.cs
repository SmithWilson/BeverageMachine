using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeverageMachine.Contracts;
using MediatR;

namespace BeverageMachine.Cqrs.Coins.Queries.Get
{
  public class QueryHandler
    : IRequestHandler<GetCoinsQuery, GetCoinsResponse>
  {
    private readonly IDataProvider<Entities.Models.Coins> _provider;

    public QueryHandler(IDataProvider<Entities.Models.Coins> provider)
    {
      _provider = provider;
    }

    public async Task<GetCoinsResponse> Handle(GetCoinsQuery request, CancellationToken cancellationToken)
    {
      var coins = await _provider.GetListAsync();
      return new GetCoinsResponse(coins);
    }
  }
}
