using Microsoft.AspNetCore.Mvc;
using TicketTable_MVC_Vue.Dal.Abstractions;
using TicketTable_MVC_Vue.Models;
using TicketTable_MVC_Vue.Models.Dto;

namespace ProjectTable_MVC_Vue.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectsController : ControllerBase

    {
        private readonly IRepository<Project> _repositoryProjects;

        public ProjectsController(IRepository<Project> repositoryProjects)
        {
            _repositoryProjects = repositoryProjects;
        }

        /// <summary>
        /// Gets List of Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var entities = await _repositoryProjects.GetAllAsync();
            return Ok(entities);
        }

        /// <summary>
        /// Gets Project By Id
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var entity = await _repositoryProjects.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// Creates Project
        /// </summary>        
        /// <param name="request">Project Dto</param>
        /// <returns>Project Id</returns>
        [HttpPost]
        public async Task<ActionResult> CreateProjectAsync(ProjectDto request)
        {
            var entity = new Project {Name = request.Name};
            await _repositoryProjects.AddAsync(entity);
            return Ok(entity.Id);
        }


        /// <summary>
        /// Deletes Project
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var entity = await _repositoryProjects.GetByIdAsync(id);

            if (entity == null)
                return NotFound();

            await _repositoryProjects.RemoveAsync(entity);

            return Ok();
        }
    }
}
