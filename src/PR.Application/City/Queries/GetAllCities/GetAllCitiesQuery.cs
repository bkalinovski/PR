using MediatR;
using PR.Application.Common.Models;

namespace PR.Application.City.Queries.GetAllCities;

public record GetAllCitiesQuery : IRequest<List<CityDto>>;