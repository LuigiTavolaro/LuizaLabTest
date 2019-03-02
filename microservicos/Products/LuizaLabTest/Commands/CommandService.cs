
using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
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

        
        public async Task<Product> SaveProduct(string nameProduct)
        {
            try
            {
                var product = new Product { name = nameProduct };
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
   
    }
}
