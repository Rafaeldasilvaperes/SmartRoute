using Microsoft.EntityFrameworkCore;
using SmartRoute.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Tests.Common
{
    public static class MockDbContext
    {
        public static SmartRouteDbContext Create()
        {
            var options = new DbContextOptionsBuilder<SmartRouteDbContext>()
                .UseInMemoryDatabase(databaseName: "SmartRouteTestDb")
                .Options;

            var context = new SmartRouteDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
