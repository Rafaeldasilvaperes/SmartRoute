
namespace SmartRoute.Application.DTOs
{
    public class DeliveryRouteDto
    {
        public Guid Id { get; set; }

        // Will receive from a different service and save it all in one column
        public string OriginAddress { get; set; }
        // Coordinates      
        public string DestinationAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
