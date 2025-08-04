
namespace SmartRoute.Domain.Entities
{
    public class DeliveryRoute
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string OriginIbgeCode { get; set; } = string.Empty;
        public string DestinationIbgeCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
