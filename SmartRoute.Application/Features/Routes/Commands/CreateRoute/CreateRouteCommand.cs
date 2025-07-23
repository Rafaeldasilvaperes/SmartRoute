using MediatR;

namespace SmartRoute.Application.Features.Routes.Commands.CreateRoute;

public record CreateRouteCommand(string Name) : IRequest<Guid>;