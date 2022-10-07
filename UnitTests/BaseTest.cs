using backend1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class BaseTest
    {
        protected ChildrenWithCourageDBContext ctx;
        public BaseTest(ChildrenWithCourageDBContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected ChildrenWithCourageDBContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ChildrenWithCourageDBContext>();
            var options = builder.UseInMemoryDatabase("testDB").UseInternalServiceProvider(serviceProvider).Options;

            ChildrenWithCourageDBContext dbContext = new ChildrenWithCourageDBContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }


    }
}
