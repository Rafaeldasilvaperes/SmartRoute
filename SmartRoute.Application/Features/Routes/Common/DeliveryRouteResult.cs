
namespace SmartRoute.Application.Features.Routes.Common
{    
    public record DeliveryRouteResult(Guid Id, string Origin, string OriginIbgeCode, string Destination, string DestinationIbgeCode);
}
