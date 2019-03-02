using System.Threading.Tasks;

namespace LuizaLabTest.Commands
{
    public interface ICommandService
    {
        Task<bool> SaveWish(int userId, int productId);
        Task<bool> DeleteWish(int userId, int productId);
        Task<bool> UpdateWish(int userId, int productIdOld, int productIdNew);
    }
}
