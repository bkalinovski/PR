using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PR.Application.Common.Interfaces;

namespace PR.Application.City.Commands.RemoveCity;

public class RemoveCityCommandHandler : IRequestHandler<RemoveCityCommand, Unit>
{
    private readonly IPrDbContext _context;
    private readonly IMapper _mapper;
    
    public RemoveCityCommandHandler(IPrDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(RemoveCityCommand request, CancellationToken cancellationToken)
    {
        var city = await _context.Orase
            .Where(t => t.CodOras == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        
        if(city == null) return Unit.Value;

        _context.Orase.Remove(city);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}