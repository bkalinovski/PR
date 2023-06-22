using MediatR;

namespace PR.Application.City.Commands.RemoveCity;

public record RemoveCityCommand(int Id) : IRequest<Unit>;