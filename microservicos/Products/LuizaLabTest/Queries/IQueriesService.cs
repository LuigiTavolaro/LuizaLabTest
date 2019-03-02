using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabTest.Queries
{
    public interface IQueriesService
    {
        Task<IEnumerable<Product>> GetAllProducts(int page_size, int page);
    }
}
