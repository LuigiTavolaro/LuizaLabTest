
using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<bool> SaveWish(int UserId, int ProductId)
        {
            try
            {

                var wish = new Wish { ProductId = ProductId, UserId = UserId };
                await _context.Wishes.AddAsync(wish);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public async Task<bool> UpdateWish(int userId, int productIdOld, int productIdnew)
        {
            try
            {
                var wish = new Wish { ProductId = productIdOld, UserId = userId };
                _context.Wishes.Remove(wish);
                wish = new Wish { ProductId = productIdnew, UserId = userId };
                await _context.Wishes.AddAsync(wish);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {

                return false;
            }


        }
        public async Task<bool> DeleteWish(int userId, int productId)
        {
            try
            {
                var wish = new Wish { ProductId = productId, UserId = userId };
                _context.Wishes.Remove(wish);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
    }
}
