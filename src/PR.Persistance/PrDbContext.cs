using Microsoft.EntityFrameworkCore;
using PR.Application.Common.Interfaces;
using PR.Domain.Oras;
using PR.Domain.Tara;

namespace PR.Persistance;

public class PrDbContext : DbContext, IPrDbContext
{
    /*
        cd PR.Persistance
        dotnet ef migrations add Initial -p ../PR.Persistance -s ../PR.Client
        dotnet ef database update -p ../PR.Persistance -s ../PR.Client
    */

    public PrDbContext(DbContextOptions<PrDbContext> options) : base(options) { }

    public DbSet<Oras> Orase { get; set; }
    
    public DbSet<Tara> Tari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrDbContext).Assembly);
    }
}