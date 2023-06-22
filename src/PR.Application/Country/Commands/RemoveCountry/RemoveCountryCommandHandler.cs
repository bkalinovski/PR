using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PR.Application.Common.Interfaces;

namespace PR.Application.Country.Commands.RemoveCountry;

public class RemoveCountryCommandHandler : IRequestHandler<RemoveCountryCommand, Unit>
{
    private readonly IPrDbContext _context;
    private readonly IMapper _mapper;

    public RemoveCountryCommandHandler(IPrDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(RemoveCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _context.Tari
            .Where(t => t.CodTara == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(country == null) return Unit.Value;

        _context.Tari.Remove(country);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}