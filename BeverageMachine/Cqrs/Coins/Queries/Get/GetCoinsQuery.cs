using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BeverageMachine.Cqrs.Coins.Queries.Get
{
  public class GetCoinsQuery
    : IRequest<GetCoinsResponse>
  {
    public GetCoinsQuery()
    {

    }
  }
}
