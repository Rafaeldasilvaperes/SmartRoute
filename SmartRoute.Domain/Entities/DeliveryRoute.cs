
namespace SmartRoute.Domain.Entities
{
    public class DeliveryRoute
    {
        public Guid Id { get; set; }

        // Will receive from a different service and save it all in one column
        public string OriginAddress { get; set; }
        // Coordinates
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }        
        public string DestinationAddress { get; set; }        
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }        
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        
    }
}
