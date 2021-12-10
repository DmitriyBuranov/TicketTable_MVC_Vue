using Microsoft.AspNetCore.Mvc;
using TicketTable_MVC_Vue.Dal.Abstractions;
using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;

namespace TicketStatusTable_MVC_Vue.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketStatusesController : ControllerBase

    {
        private readonly IRepository<TicketStatus> _repositoryTicketStatuses;

        public TicketStatusesController(IRepository<TicketStatus> repositoryTicketStatuses)
        {
            _repositoryTicketStatuses = repositoryTicketStatuses;
        }

        /// <summary>
        /// Gets List of TicketStatuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTicketStatusesAsync()
        {
            var entities = await _repositoryTicketStatuses.GetAllAsync();
            return Ok(entities);
        }

        /// <summary>
        /// Gets TicketStatus By Id
        /// </summary>
        /// <param name="id">TicketStatus Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketStatusAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entity = await _repositoryTicketStatuses.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

       


        /// <summary>
        /// Deletes TicketStatus
        /// </summary>
        /// <param name="id">TicketStatus Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteTicketStatus(int id)
        {
            var entity = await _repositoryTicketStatuses.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryTicketStatuses.RemoveAsync(entity);

            return Ok();
        }
    }
}
