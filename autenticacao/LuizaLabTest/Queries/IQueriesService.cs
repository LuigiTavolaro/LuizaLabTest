using LuizaLabTest.DTO;
using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabTest.Queries
{
    public interface IQueriesService
    {
        Task<IEnumerable<User>> GetAllUsers(int page_size, int page);
        Task<IEnumerable<Product>> GetAllProducts(int page_size, int page);
        Task<IEnumerable<Product>> GetWishes(int userId, int page_size, int page);

        UserToken Find(string userID);
    }
}
