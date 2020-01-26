using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeverageMachine.Entities.Dtos;
using BeverageMachine.Entities.Models;

namespace BeverageMachine.Tools
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Coins, CoinDto>().ReverseMap();
      CreateMap<Drink, DrinkDto>().ReverseMap();
    }
  }
}
