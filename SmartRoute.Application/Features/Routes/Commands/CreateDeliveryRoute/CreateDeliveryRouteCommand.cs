using MediatR;
using SmartRoute.Application.DTOs;
using SmartRoute.Domain.Entities;

namespace SmartRoute.Application.Features.Routes.Commands.CreateDeliveryRoute;

public record CreateDeliveryRouteCommand(DeliveryRouteDto dto) : IRequest<DeliveryRoute>;
