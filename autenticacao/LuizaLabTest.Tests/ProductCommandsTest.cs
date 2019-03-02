using LuizaLabTest.Commands;
using LuizaLabTest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LuizaLabTest.Tests
{
    public class ProductCommandsTest
    {
        [Fact]
        public async Task Test1()
        {

            var options = new DbContextOptionsBuilder<LuizaLabContext>()
                           .UseInMemoryDatabase(databaseName: "mem-test")
                           .Options;

            Product product;
            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                product = await commands.SaveProduct("batedeira");
            }

            using (var context = new LuizaLabContext(options))
            {
                Assert.True(await context.Products.AnyAsync(p => p.id == product.id));
            }
        }
    }
}
