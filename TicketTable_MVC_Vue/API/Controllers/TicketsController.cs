using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TicketTable_MVC_Vue.Dal.Abstractions;
using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;
using TicketTable_MVC_Vue.Models.Mappers;
using TicketTable_MVC_Vue.Models.Responses;

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

        /// <summary>
        /// Gets List of Tickets with full info
        /// </summary>
        /// <param name="id"></param>
        /// <returns> TicketWithInfoResponse</returns>
        [HttpGet("WithInfo")]
        public async Task<IActionResult> GetAllTicketsWithClientsAsync()
        {
            Expression<Func<Ticket, bool>> expression = x => true; 

            var entities = await _repositoryTickets
                .GetManySelectAsync<TicketWithInfoResponse>(expression, entity => new TicketWithInfoResponse
                {
                    Id = entity.Id,
                    ProjectName = entity.Project.Name,
                    ProjectId = entity.ProjectId,
                    Description = entity.Description,
                    TicketStatusName = entity.TicketStatus.Name,
                    TicketStatusId = entity.TicketStatusId,
                    OpenedAt = entity.OpenedAt,
                    ClosedAt = entity.ClosedAt,
                    AuthorFullName = entity.Author.FullName,
                    AuthorUserId = entity.AuthorUserId,
                    ClosedByFullName = entity.ClosedBy.FullName,
                    ClosedByUserId = entity.ClosedByUserId
                });

            return Ok(entities);
        }
    }

}
