using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeverageMachine.Entities.Models
{
  public class Drink
  {
    public int Id { get; set; }
    /// <summary>
    /// Количество напитка в автомате
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// Название напитка
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Путь на ресурс - изображение напитка
    /// </summary>
    public string ImageUri { get; set; }

    public void UpdateFromSource(Drink drink)
    {
      if (drink.Count >= 0)
      {
        Count = drink.Count;
      }

      if (drink.Price > 0)
      {
        Price = drink.Price;
      }

      if (!string.IsNullOrWhiteSpace(drink.Name))
      {
        Name = drink.Name;
      }

      if (!string.IsNullOrWhiteSpace(drink.ImageUri))
      {
        ImageUri = drink.ImageUri;
      }
    }
  }
}
