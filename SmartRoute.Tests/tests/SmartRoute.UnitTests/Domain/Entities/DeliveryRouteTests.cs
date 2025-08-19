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
            var deliveryRoute = new DeliveryRoute();

            // Act & Assert
            Assert.Equal("São Paulo", deliveryRoute.Origin);
            Assert.NotEqual(Guid.Empty, deliveryRoute.Id);
        }
    }
}
