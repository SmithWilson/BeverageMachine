using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BeverageMachine.Cqrs.Drink.Queries.Get
{
  public class GetDrinkQuery
    : IRequest<GetDrinkResponse>
  {
    public GetDrinkQuery()
    {

    }
  }
}
