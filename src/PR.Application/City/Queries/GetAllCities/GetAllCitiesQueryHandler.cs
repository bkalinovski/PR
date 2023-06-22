using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PR.Application.Common.Interfaces;
using PR.Application.Common.Models;

namespace PR.Application.City.Queries.GetAllCities;

public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, List<CityDto>>
{
    private readonly IPrDbContext _context;
    private readonly IMapper _mapper;
    
    public GetAllCitiesQueryHandler(IPrDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<CityDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Orase
            .Include(t => t.Tara)
            .AsNoTracking()
            .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}