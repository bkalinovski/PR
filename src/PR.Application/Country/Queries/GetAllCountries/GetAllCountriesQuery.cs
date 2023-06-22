using MediatR;
using PR.Application.Common.Models;

namespace PR.Application.Country.Queries.GetAllCountries;

public record GetAllCountriesQuery() : IRequest<List<CountryDto>>;