namespace BeverageMachine.Entities.Models
{
  public class Coins
  {
    public Coins()
    {
    }

    public int Id { get; set; }
    /// <summary>
    /// Активна ли монета
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// Номинал
    /// </summary>
    public int Par { get; set; }

    public int Count { get; set; }

    public void UpdateFromSource(Coins coin)
    {
      IsActive = coin.IsActive;
      if (coin.Par > 0)
      {
        Par = coin.Par;
      }

      if (coin.Count >= 0)
      {
        Count = coin.Count;
      }
    }
  }
}
