using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace BeverageMachine.Entities.Dtos
{
  public class DrinkDto
  {
    [Min(0)]
    [Required]
    public int Count { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    [Min(1)]
    [Required]
    public decimal Price { get; set; }
    /// <summary>
    /// Название напитка
    /// </summary>
    [MinLength(1)]
    public string Name { get; set; }
    /// <summary>
    /// Путь на ресурс - изображение напитка
    /// </summary>
    [Required]
    public string ImageUri { get; set; }
  }
}
