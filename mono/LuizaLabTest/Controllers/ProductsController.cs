using LuizaLabTest.Commands;
using LuizaLabTest.DTO;
using LuizaLabTest.Model;
using LuizaLabTest.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizaLabTest.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IQueriesService _queries;
        private readonly ICommandService _commands;

        public ProductsController(IQueriesService queries, ICommandService commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get(int page_size, int page)
        {
            return (await _queries.GetAllProducts(page_size, page)).ToList();
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductPayloadDto value)
        {
            try
            {
                await _commands.SaveProduct(value.name);

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
            }
            catch (Exception)
            {

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

    }
}