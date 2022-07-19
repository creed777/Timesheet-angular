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
        [HttpGet("{projectId}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int projectId)
        {
            if (projectId == 0)
                return BadRequest("Project id cannot be null");

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
                return BadRequest(new ArgumentNullException("project"));

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
        /// Hard deletes a project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            if (projectId == 0)
                return BadRequest();

            var result = await _projectDomain.DeleteProject(projectId);
            if(result != -1)
            {
                return Ok(await _projectDomain.DeleteProject(projectId));
            }
            else
            {
                return BadRequest("There was a problem deleting the project");
            }    
        }
    }
}
