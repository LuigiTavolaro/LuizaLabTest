using LuizaLabTest.Model;
using System.Threading.Tasks;

namespace LuizaLabTest.Commands
{
    public interface ICommandService
    {
        Task<User> SaveUser(string nameUser, string emailUser);
    }
}
