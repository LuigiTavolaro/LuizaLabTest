using LuizaLabTest.Commands;
using LuizaLabTest.DTO;
using LuizaLabTest.Model;
using LuizaLabTest.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public ProductsController(IQueriesService queries, ICommandService commands, ILogger<ProductsController> logger)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get(int page_size, int page)
        {
            try
            {
                return (await _queries.GetAllProducts(page_size, page)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductPayloadDto value)
        {
            try
            {
                await _commands.SaveProduct(value.name);

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

    }
}