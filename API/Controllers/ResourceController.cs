using API.Interfaces;
using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Endpoint to manage project resources
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceDomain _resourceDomain;

        public ResourceController(IResourceDomain projectDomain)
        {
            _resourceDomain = projectDomain;
        }

        /// <summary>
        /// Get resource type list
        /// </summary>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult<List<ResourceTypeDto>>> GetResourceTypeList()
        {
            return await _resourceDomain.GetResourceTypeList();
        }

        /// <summary>
        /// Returns all active project resources fo the given type
        /// </summary>
        /// <returns><see cref="IEnumerable{ResourceDto}"/></returns>
        [HttpGet("{resourceTypeId}")]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResourcesByTypeAsync(int resourceTypeId)
        {
            if(resourceTypeId == 0)
                return BadRequest(new ArgumentNullException(resourceTypeId.ToString()));

            return await _resourceDomain.GetResourcesByTypeAsync(resourceTypeId);
        }

        /// <summary>
        /// Get a resurce by id
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns><see cref="ActionResult{ResourceModel}"/></returns>
        [HttpGet("{resourceId}")]
        public async Task<ActionResult<ResourceDto>> GetResourceByIdAsync(int resourceId)
        {
            if (resourceId == 0)
                return BadRequest(new ArgumentNullException());

            var resource = await _resourceDomain.GetResourceByIdAsync(resourceId);
            return resource;
        }

        //// PUT: api/Resource/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutResourceModel(int id, ResourceModel resourceModel)
        //{
        //    if (id != resourceModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _project.Entry(resourceModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ResourceModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// Add a new resource
        /// </summary>
        /// <param name="resource"></param>
        /// <returns><see cref="ActionResult{TValue}"/></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> AddResourceAsync(CreateResourceDto resource)
        {
            if (resource == null)
                return BadRequest(new ArgumentNullException());

            var result = await _resourceDomain.AddResourceAsync(resource);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("There was a problem adding the project");
            }
        }

        /// <summary>
        /// Hard deletes a resource
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("{resourceId}")]
        public async Task<IActionResult> DeleteResource(int resourceId)
        {
            if (resourceId == 0)
                return BadRequest(new ArgumentNullException());

            var result = await _resourceDomain.DeleteResourceAsync(resourceId);
            if(result != -1)
            {
                return Ok();
            }
            else
            {
                return BadRequest("There was an error deleting the resource");
            }
        }
    }
}
