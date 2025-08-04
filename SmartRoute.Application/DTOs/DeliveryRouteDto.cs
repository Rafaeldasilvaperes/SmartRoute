
namespace SmartRoute.Application.DTOs
{
    public class DeliveryRouteDto
    {
        public string Origin { get; set; } = string.Empty;
        public string OriginIbgeCode { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;        
        public string DestinationIbgeCode { get;set; } = string.Empty;
    }
}
