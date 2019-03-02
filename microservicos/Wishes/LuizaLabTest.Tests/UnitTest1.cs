using LuizaLabTest.Commands;
using LuizaLabTest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LuizaLabTest.Tests
{
    public class CommandsTest
    {
        [Fact]
        public async Task Test1()
        {
            int userID = 1;
            int productID = 1;


            var options = new DbContextOptionsBuilder<LuizaLabContext>()
                .UseInMemoryDatabase(databaseName: "mem-test")
                .Options;

            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                Assert.True(await commands.SaveWish(userID, productID));
            }

            using (var context = new LuizaLabContext(options))
            {
                Assert.True(await context.Wishes.AnyAsync(p => p.UserId == userID));
            }
        }
        [Fact]
        public async Task Update()
        {
            int userID = 1;
            int productIDold = 1;
            int productIDnew = 2;


            var options = new DbContextOptionsBuilder<LuizaLabContext>()
                .UseInMemoryDatabase(databaseName: "mem-test")
                .Options;

            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                Assert.True(await commands.SaveWish(userID, productIDold));
            }

            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                Assert.True(await commands.UpdateWish(userID, productIDold, productIDnew));
            }

            using (var context = new LuizaLabContext(options))
            {
                Assert.True(await context.Wishes.AnyAsync(p => p.UserId == userID && p.ProductId == productIDnew));
            }
        }
        [Fact]
        public async Task Delete()
        {
            int userID = 1;
            int productID = 1;


            var options = new DbContextOptionsBuilder<LuizaLabContext>()
                .UseInMemoryDatabase(databaseName: "mem-test")
                .Options;


            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                Assert.True(await commands.SaveWish(userID, productID));
            }


            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                Assert.True(await commands.DeleteWish(userID, productID));
            }

            using (var context = new LuizaLabContext(options))
            {
                Assert.False(await context.Wishes.AnyAsync(p => p.UserId == userID && p.ProductId == productID));
            }
        }
    }
}
