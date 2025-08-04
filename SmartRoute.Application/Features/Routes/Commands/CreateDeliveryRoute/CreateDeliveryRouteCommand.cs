using MediatR;

namespace SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;

public record CreateDeliveryRouteCommand(string Name) : IRequest<Guid>;