using Microsoft.AspNetCore.Routing;
using SmartRoute.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Tests.tests.SmartRoute.UnitTests.Domain.Entities
{
    public class DeliveryRouteTests
    {
        [Fact]
        public void CreateRoute_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var deliveryRoute = new DeliveryRoute { Id = Guid.NewGuid(), OriginAddress = "Rota Teste", DestinationAddress = "1234567" };

            // Act & Assert
            Assert.Equal("Rota Teste", deliveryRoute.OriginAddress);
            Assert.NotEqual(Guid.Empty, deliveryRoute.Id);
        }
    }
}
