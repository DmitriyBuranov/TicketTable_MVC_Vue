using Microsoft.AspNetCore.Mvc;
using TicketTable_MVC_Vue.Dal.Abstractions;
using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;
using UserTable_MVC_Vue.Models.Mappers;

namespace TicketTable_MVC_Vue.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repositoryUsers;

        public UsersController(IRepository<User> repositoryUsers)
        {
            _repositoryUsers = repositoryUsers;
        }

        /// <summary>
        /// Gets List of Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var entities = await _repositoryUsers.GetAllAsync();
            return Ok(entities);
        }

        /// <summary>
        /// Gets User By Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entity = await _repositoryUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Creates User
        /// </summary>        
        /// <param name="request">User Dto</param>
        /// <returns>User Id</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(UserDto request)
        {
            var entity = UserMapper.MapFromModel(request);
            await _repositoryUsers.AddAsync(entity);
            return Ok(entity.Id);
        }


        /// <summary>
        /// Deletes User
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var entity = await _repositoryUsers.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryUsers.RemoveAsync(entity);

            return Ok();
        }
    }
}
