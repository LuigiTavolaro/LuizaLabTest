using LuizaLabTest.Commands;
using LuizaLabTest.DTO;
using LuizaLabTest.Model;
using LuizaLabTest.Queries;
using Microsoft.AspNetCore.Authorization;
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
    public class WishesController : ControllerBase
    {

        private readonly IQueriesService _queries;
        private readonly ICommandService _commands;

        private readonly ILogger _logger;

        public WishesController(IQueriesService queries, ICommandService commands, ILogger<WishesController> logger)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));

            _logger = logger;
        }
        [Authorize("Bearer")]
        [HttpGet("{idUser}")]
        public async Task<IEnumerable<Product>> Get(int idUser, int page_size, int page)
        {
            try
            {
                return (await _queries.GetWishes(idUser, page_size, page)).ToList();
            }
            catch (Exception ex)
            {


                _logger.LogInformation(ex.Message);
                return null;
            }
        }
        [Authorize("Bearer")]
        [HttpPost("{userId}")]
        public async Task<IActionResult> SaveWish(int userId, [FromBody] List<WishPayloadDto> value)
        {
            try
            {

                foreach (var item in value)
                {
                    await _commands.SaveWish(userId, item.idProduct);

                }
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
        [Authorize("Bearer")]
        [HttpPut("{userId}/{productIdOld}/{productIdNew}")]
        public async Task<IActionResult> UpdateWish(int userId, int productIdOld, int productIdNew)
        {
            try
            {

                await _commands.UpdateWish(userId, productIdOld, productIdNew);

                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
        [Authorize("Bearer")]
        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteWish(int userId, int productId)
        {
            try
            {

                await _commands.DeleteWish(userId, productId);

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