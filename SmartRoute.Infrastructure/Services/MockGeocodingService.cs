using SmartRoute.Application.Interfaces;

namespace SmartRoute.Infrastructure.Services
{
    public class MockGeocodingService : IGeocodingService
    {
        public Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            // Return random or fixed values
            var random = new Random();
            double lat = -23.5505 + random.NextDouble() / 100;  // Close to SP
            double lon = -46.6333 + random.NextDouble() / 100;

            return Task.FromResult((lat, lon));
        }
    }
}
