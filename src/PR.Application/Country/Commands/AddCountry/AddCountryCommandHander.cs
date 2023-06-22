using AutoMapper;
using MediatR;
using PR.Application.Common.Interfaces;
using PR.Domain.Tara;

namespace PR.Application.Country.Commands.AddCountry;

public class AddCountryCommandHander : IRequestHandler<AddCountryCommand, int>
{
    private readonly IPrDbContext _context;
    private readonly IMapper _mapper;

    public AddCountryCommandHander(IPrDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Tara(request.Description, request.Continent);

        await _context.Tari.AddAsync(country, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return country.CodTara;
    }
}