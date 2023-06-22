using PR.Application.Common.Interfaces;
using PR.Domain.Oras;
using PR.Domain.Shared;
using PR.Domain.Tara;

namespace PR.Application.System.Commands.SeedSampleData;

public class SampleDataSeeder
{
    private readonly IPrDbContext _context;

    public SampleDataSeeder(IPrDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedAllAsync(CancellationToken cancellationToken)
    {
        if (_context.Tari.Any())
        {
            return;
        }

        await SeedCountriesAsync(cancellationToken);
        await SeedCitiesAsync(cancellationToken);
    }

    private async Task SeedCountriesAsync(CancellationToken cancellationToken)
    {
        var countries = new[]
        {
            new Tara("Moldova", Continent.Europa),
            new Tara("Italia", Continent.Europa),
            new Tara("China", Continent.Asia)
        };

        _context.Tari.AddRange(countries);

        await _context.SaveChangesAsync(cancellationToken);
    }
    
    private async Task SeedCitiesAsync(CancellationToken cancellationToken)
    {
        var cities = new[]
        {
            new Oras("Chisinau", 10000, 1),
            new Oras("Drochia", 1000, 1),
            new Oras("Edinet", 500, 1),
            new Oras("Hong Kong", 240000, 3),
            new Oras("Rome", 52000, 2),
            new Oras("Florence", 12000, 2),
            new Oras("Siena", 11500, 2)
        };

        _context.Orase.AddRange(cities);

        await _context.SaveChangesAsync(cancellationToken);
    }
}