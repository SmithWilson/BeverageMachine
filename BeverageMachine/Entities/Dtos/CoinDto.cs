using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace BeverageMachine.Entities.Dtos
{
  public class CoinDto
  {
    /// <summary>
    /// Активна ли монета
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Номинал
    /// </summary>
    [Min(1)]
    [Required]
    public int Par { get; set; }

    [Min(0)]
    public int Count { get; set; } = 0;
  }
}
