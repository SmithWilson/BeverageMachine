using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.CommonTools;

namespace BeverageMachine.Cqrs.Drink.Specifications
{
  public class GetDrinkByIdSpec
    : Specification<Entities.Models.Drink>
  {
    public GetDrinkByIdSpec(int id)
    {
      Predicate = drink => drink.Id == id;
    }
  }
}
