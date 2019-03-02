
using LuizaLabTest.Model;
using System;
using System.Threading.Tasks;

namespace LuizaLabTest.Commands
{
    public class CommandService : ICommandService
    {
        private readonly LuizaLabContext _context;

        public CommandService(LuizaLabContext context)
        {
             _context = context ?? throw new ArgumentNullException(nameof(context));
        }

     

        public async Task<User> SaveUser(string nameUser, string emailUser)
        {
            try
            {
                var user = new User { name = nameUser, email = emailUser };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }

    
        }
    }
}
