using Microsoft.EntityFrameworkCore;

namespace PR.Persistance;

public class PrDbContextFactory : DesignTimeDbContextFactoryBase<PrDbContext>
{
    protected override PrDbContext CreateNewInstance(DbContextOptions<PrDbContext> options)
    {
        return new PrDbContext(options);
    }
}