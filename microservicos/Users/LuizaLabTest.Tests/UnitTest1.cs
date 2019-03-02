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

            var options = new DbContextOptionsBuilder<LuizaLabContext>()
                .UseInMemoryDatabase(databaseName: "mem-test")
                .Options;

            User user;
            using (var context = new LuizaLabContext(options))
            {
                var commands = new CommandService(context);
                user = await commands.SaveUser("luigi", "luigisant@gmail.com");
            }

            using (var context = new LuizaLabContext(options))
            {
                Assert.True(await context.Users.AnyAsync(p => p.id == user.id));
            }
        }
    }
}
