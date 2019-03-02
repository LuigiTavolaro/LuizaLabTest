using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabTest.Commands
{
    public interface ICommandService
    {
        Task<Product> SaveProduct(string nameProduct);
    }
}
