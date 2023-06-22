using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PR.Application.Common.Interfaces;
using PR.Application.Common.Models;

namespace PR.Application.Country.Queries.GetAllCountries;

public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<CountryDto>>
{
    private readonly IPrDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCountriesQueryHandler(IPrDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tari
            .AsNoTracking()
            .ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}