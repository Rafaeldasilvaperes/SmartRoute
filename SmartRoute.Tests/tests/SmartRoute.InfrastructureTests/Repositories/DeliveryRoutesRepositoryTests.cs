using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SmartRoute.Domain.Entities;
using SmartRoute.Infrastructure.Persistence;
using SmartRoute.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Tests.tests.SmartRoute.InfrastructureTests.Repositories
{
    public class DeliveryRoutesRepositoryTests
    {
        private SmartRouteDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SmartRouteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SmartRouteDbContext(options);
        }

        [Fact]
        public async Task AddRoute_ShouldPersistRoute()
        {
            // Arrange
            using var context = CreateDbContext();
            var repository = new DeliveryRouteRepository(context);

            var route = new DeliveryRoute { Id = Guid.NewGuid(), OriginAddress = "Rota Teste", DestinationAddress = "1234567" };

            // Act
            await repository.AddAsync(route);
            await context.SaveChangesAsync();

            // Assert
            var saved = await context.DeliveryRoute.FirstOrDefaultAsync(r => r.Id == route.Id);
            Assert.NotNull(saved);
            Assert.Equal("Rota Teste", saved!.OriginAddress);
        }
    }
}
