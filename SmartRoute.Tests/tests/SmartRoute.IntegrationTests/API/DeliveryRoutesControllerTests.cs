using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SmartRoute.Tests.tests.SmartRoute.IntegrationTests.API
{
    public class DeliveryRoutesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public DeliveryRoutesControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllDeliveryRoutes_ShouldReturnSuccess()
        {
            var response = await _client.GetAsync("/api/DeliveryRoutes");

            response.EnsureSuccessStatusCode();
        }
    }
}
