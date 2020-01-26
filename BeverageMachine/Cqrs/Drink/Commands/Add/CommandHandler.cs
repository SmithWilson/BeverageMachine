using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using BeverageMachine.Contracts;

using MediatR;

namespace BeverageMachine.Cqrs.Drink.Commands.Add
{
  public class CommandHandler
    : IRequestHandler<AddDrinkCommand, AddDrinkResult>
  {
    private readonly IDataProvider<Entities.Models.Drink> _provider;
    private readonly IMapper _mapper;

    public CommandHandler(
      IDataProvider<Entities.Models.Drink> provider,
      IMapper mapper)
    {
      _provider = provider;
      _mapper = mapper;
    }

    public async Task<AddDrinkResult> Handle(AddDrinkCommand request, CancellationToken cancellationToken)
    {
      Entities.Models.Drink entity = _mapper.Map<Entities.Models.Drink>(request.DrinkDto);

      _provider.Add(entity);
      await _provider.SaveAsync();

      return new AddDrinkResult(entity);
    }
  }
}
