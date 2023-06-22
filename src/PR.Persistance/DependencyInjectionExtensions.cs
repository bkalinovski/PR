using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PR.Application.Common.Interfaces;

namespace PR.Persistance;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PrDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PrDatabase")));

        services.AddScoped<IPrDbContext>(provider => provider.GetService<PrDbContext>());

        return services;
    }
}
