using AutoMapper;
using PR.Application.Common.Models;
using PR.Domain.Oras;
using PR.Domain.Tara;

namespace PR.Application.Common.Mappings;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile()
    {
        CreateMap<Tara, CountryDto>()
            .ForMember(t => t.Id, expression => expression.MapFrom(p => p.CodTara))
            .ForMember(t => t.Description, expression => expression.MapFrom(p => p.Denumire))
            .ForMember(t => t.Continent, expression => expression.MapFrom(p => p.Continent));
        
        CreateMap<Oras, CityDto>()
            .ForMember(t => t.Id, expression => expression.MapFrom(p => p.CodTara))
            .ForMember(t => t.Description, expression => expression.MapFrom(p => p.Denumire))
            .ForMember(t => t.NrOfPeople, expression => expression.MapFrom(p => p.NumarLocuitori))
            .ForMember(t => t.Country, expression => expression.MapFrom(p => p.Tara.Denumire));
    }
}