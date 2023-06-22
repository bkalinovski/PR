using MediatR;

namespace PR.Application.Country.Commands.RemoveCountry;

public record RemoveCountryCommand(int Id) : IRequest<Unit>;