using Dapper;
using LuizaLabTest.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

       
       
        public async Task<IEnumerable<ProductDto>> GetWishes(int userId, int page_size, int page)
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

                return await conn.QueryAsync<ProductDto>(sql.ToString());
            }
        }
    }
}
