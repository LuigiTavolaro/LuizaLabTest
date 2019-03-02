using Dapper;
using LuizaLabTest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabTest.Queries
{
    public class QueriesService : IQueriesService
    {
        private readonly string _connectionString;

        public QueriesService(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("message", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task<IEnumerable<User>> GetAllUsers(int page_size, int page)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();


                StringBuilder sql = new StringBuilder();


                sql.AppendLine("SELECT id, name, email");
                sql.AppendLine("FROM dbo.[Users] with(nolock)");
                sql.AppendLine("ORDER BY Id ");
                sql.AppendLine($"OFFSET {page_size} * ({page} - 1) ROWS");
                sql.AppendLine($"FETCH NEXT {page_size} ROWS ONLY;");


                return await conn.QueryAsync<User>(sql.ToString());
            }
        }
        public async Task<IEnumerable<Product>> GetAllProducts(int page_size, int page)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();


                StringBuilder sql = new StringBuilder();


                sql.AppendLine("SELECT id, name");
                sql.AppendLine("FROM dbo.[Products] with(nolock)");
                sql.AppendLine("ORDER BY Id ");
                sql.AppendLine($"OFFSET {page_size} * ({page} - 1) ROWS");
                sql.AppendLine($"FETCH NEXT {page_size} ROWS ONLY;");


                return await conn.QueryAsync<Product>(sql.ToString());
            }
        }

        public async Task<IEnumerable<Product>> GetWishes(int userId, int page_size, int page)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();


                StringBuilder sql = new StringBuilder();


                sql.AppendLine("SELECT p.Id,p.name");
                sql.AppendLine("FROM Wishes w with(nolock)");
                sql.AppendLine("INNER JOIN Products p with(nolock) on w.ProductId = p.Id");
                sql.AppendLine($"WHERE UserId = {userId}");
                sql.AppendLine("ORDER BY p.Id ");
                sql.AppendLine($"OFFSET {page_size} * ({page} - 1) ROWS");
                sql.AppendLine($"FETCH NEXT {page_size} ROWS ONLY;");


                return await conn.QueryAsync<Product>(sql.ToString());
            }
        }
    }
}
