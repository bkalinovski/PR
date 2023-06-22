using MediatR;
using PR.Domain.Shared;

namespace PR.Application.Country.Commands.AddCountry;

public record AddCountryCommand(string Description, Continent Continent) : IRequest<int>;