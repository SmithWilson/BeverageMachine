namespace BeverageMachine.Cqrs.Coins.Commands.Update
{
  public class UpdateCoinResult
  {
    public UpdateCoinResult(Entities.Models.Coins coin)
    {
      Coin = coin ?? throw new System.ArgumentNullException(nameof(coin));
    }

    public Entities.Models.Coins Coin { get; set; }
  }
}
