using System.Threading;
using System.Threading.Tasks;

using BeverageMachine.Contracts;
using BeverageMachine.Cqrs.Drink.Specifications;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Queries.GetById
{
  public class QueryHandler
     : IRequestHandler<GetDrinkByIdQuery, GetDrinkByIdResponse>
  {
    private readonly IDataProvider<Entities.Models.Drink> _provider;

    public QueryHandler(IDataProvider<Entities.Models.Drink> provider)
    {
      _provider = provider;
    }

    public async Task<GetDrinkByIdResponse> Handle(GetDrinkByIdQuery request, CancellationToken cancellationToken)
    {
      Entities.Models.Drink drink = await _provider.GetAsync(new GetDrinkByIdSpec(request.Id));
      return new GetDrinkByIdResponse(drink);
    }
  }
}
