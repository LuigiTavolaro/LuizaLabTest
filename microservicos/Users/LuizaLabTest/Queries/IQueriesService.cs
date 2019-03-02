using LuizaLabTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabTest.Queries
{
    public interface IQueriesService
    {
        Task<IEnumerable<User>> GetAllUsers(int page_size, int page);
    }
}
