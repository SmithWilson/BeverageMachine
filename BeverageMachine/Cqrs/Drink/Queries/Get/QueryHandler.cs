using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using BeverageMachine.Contracts;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Queries.Get
{
  public class QueryHandler
    : IRequestHandler<GetDrinkQuery, GetDrinkResponse>
  {
    private readonly IDataProvider<Entities.Models.Drink> _provider;

    public QueryHandler(IDataProvider<Entities.Models.Drink> provider)
    {
      _provider = provider;
    }

    public async Task<GetDrinkResponse> Handle(GetDrinkQuery request, CancellationToken cancellationToken)
    {
      List<Entities.Models.Drink> drinks = await _provider.GetListAsync();
      return new GetDrinkResponse(drinks);
    }
  }
}
