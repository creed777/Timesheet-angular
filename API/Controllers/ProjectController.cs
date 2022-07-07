using API.Interfaces;
using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectDomain _projectDomain;

        public ProjectController(IProjectDomain projectDomain)
        {
            _projectDomain = projectDomain;
        }

        /// <summary>
        /// Returns a list of all active projects.
        /// </summary>
        /// <returns><see cref="IEnumerable{ProjectModel}"/></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects()
        {
          return Ok(await _projectDomain.GetAllProjects());
        }

        /// <summary>
        /// Returns a project by project id.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns><see cref="ProjectModel" /></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /API/Project/GetProject/{projectId}
        ///
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProject(string projectId)
        {
            if (projectId == null)
                return BadRequest();

            return Ok(await _projectDomain.GetProject(projectId));

        }

        /// <summary>
        /// Creates a new project.  If there  is an exception saving the project, the Id field will be null.
        /// </summary>
        /// <param name="project"></param>
        /// <returns><see cref="ActionResult{ProjectDto}"/></returns>
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> AddProject(ProjectDto project)
        {
            if (project == null)
                return BadRequest("There was a problem adding the project.  Ensure all required fields are provided");

            var result = await _projectDomain.AddProject(project);
            if(result > 0)
            {
                return CreatedAtAction(nameof(AddProject), new { id = project.ProjectId }, project);
            }
            else
            {
                return BadRequest("There was a problem adding the project");
            }
        }

        /// <summary>
        /// Hard-deletes a project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
                return BadRequest();

            var project = await _projectDomain.GetProject(projectId);
            if (project == null)
            {
                return NoContent();
            }

            return Ok(await _projectDomain.DeleteProject(projectId));
        }
    }
}
