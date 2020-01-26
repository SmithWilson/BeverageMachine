using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BeverageMachine.Cqrs.Drink.Queries.GetById
{
  public class GetDrinkByIdQuery
    : IRequest<GetDrinkByIdResponse>
  {
    public GetDrinkByIdQuery(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
