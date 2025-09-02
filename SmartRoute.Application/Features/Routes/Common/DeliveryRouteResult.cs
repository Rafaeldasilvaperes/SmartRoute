
namespace SmartRoute.Application.Features.Routes.Common
{
    public record DeliveryRouteResult(Guid Id, string OriginAddress, string DestinationAddress, DateTime CreatedAt);
}
