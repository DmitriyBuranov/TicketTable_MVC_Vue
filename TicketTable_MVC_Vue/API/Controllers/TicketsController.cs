using Microsoft.AspNetCore.Mvc;
using TicketTable_MVC_Vue.Dal.Abstractions;
using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;
using TicketTable_MVC_Vue.Models.Mappers;

namespace TicketTable_MVC_Vue.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IRepository<Ticket> _repositoryTickets;

        public TicketsController(IRepository<Ticket> repositoryTickets)
        {
            _repositoryTickets = repositoryTickets;
        }

        /// <summary>
        /// Gets List of Tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var entities = await _repositoryTickets.GetAllAsync();
            return Ok(entities);
        }

        /// <summary>
        /// Gets Ticket By Id
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entity = await _repositoryTickets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Creates Ticket
        /// </summary>        
        /// <param name="request">Ticket Dto</param>
        /// <returns>Ticket Id</returns>
        [HttpPost]
        public async Task<ActionResult> CreateTicketAsync(TicketDto request)
        {
            var entity = TicketMapper.MapFromModel(request);

            await _repositoryTickets.AddAsync(entity);

            return Ok(entity.Id);
        }

        /// <summary>
        /// Updates Ticket
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <param name="request">Ticket Dto</param> 
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicketAsync(int id, TicketDto request)
        {
            var entity = await _repositoryTickets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            TicketMapper.MapFromModel(request, entity);
            await _repositoryTickets.UpdateAsync(entity);

            return Ok();
        }

        /// <summary>
        /// Deletes Ticket
        /// </summary>
        /// <param name="id">Ticket Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var entity = await _repositoryTickets.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryTickets.RemoveAsync(entity);

            return Ok();
        }
    }

}
