using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabTest.Commands
{
    public interface ICommandService
    {
        Task<User> SaveUser(string nameUser, string emailUser);
        Task<Product> SaveProduct(string nameProduct);
        Task<bool> SaveWish(int UserId, int ProductId);
        Task<bool> DeleteWish(int userId, int productId);
        Task<bool> UpdateWish(int userId, int productIdOld, int productIdNew);
    }
}
