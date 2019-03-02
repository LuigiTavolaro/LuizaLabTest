using LuizaLabTest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabTest.Queries
{
    public interface IQueriesService
    {
        Task<IEnumerable<ProductDto>> GetWishes(int userId, int page_size, int page);
    }
}
