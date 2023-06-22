using MediatR;
using PR.Application.Common.Interfaces;

namespace PR.Application.System.Commands.SeedSampleData;

public class SeedSampleDataCommand : IRequest
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IPrDbContext _context;

        public SeedSampleDataCommandHandler(IPrDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}