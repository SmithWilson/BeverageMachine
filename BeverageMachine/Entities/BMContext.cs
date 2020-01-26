using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BeverageMachine.Entities.Models;
using BeverageMachine.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeverageMachine.Entities
{
  public class BMContext : DbContext
  {
    private readonly string _contentRootPath;
    private string _connectionString;

    public BMContext(
      IHostingEnvironment environment,
      IConfiguration configuration)
    {
      _contentRootPath = environment.ContentRootPath;
      _connectionString = configuration.GetSection(nameof(DbOption)).Get<DbOption>().ConnectionStrings;
      if (_connectionString.Contains("%CONTENTROOTPATH%"))
      {
        _connectionString = _connectionString.Replace("%CONTENTROOTPATH%", _contentRootPath);
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(_connectionString);

    public DbSet<Coins> Coins { get; set; }
    public DbSet<Drink> Drinks { get; set; }
  }
}
