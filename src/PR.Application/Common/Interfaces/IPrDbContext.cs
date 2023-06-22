using Microsoft.EntityFrameworkCore;
using PR.Domain.Oras;
using PR.Domain.Tara;

namespace PR.Application.Common.Interfaces;

public interface IPrDbContext
{
    DbSet<Oras> Orase { get; set; }
    
    DbSet<Tara> Tari { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}