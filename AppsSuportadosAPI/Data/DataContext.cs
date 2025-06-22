using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppSuportadoAPI.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace AppSuportadoAPI.Data{
  public class DataContext : DbContext{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<AppSuportado> TB_APPUPORTADO { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
      modelBuilder.Entity<AppSuportado>().ToTable("TB_APPUPORTADO");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
  }
}