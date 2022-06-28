using API.Interfaces;
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

        // GET: api/Resource
        /// <summary>
        /// Returns all active project resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceModel>>> GetAllProjectResources()
        {
            return await _resourceDomain.GetAllResourcesAsync();
        }

        // GET: api/Resource/5
        [HttpGet("{projectId}")]
        public async Task<ActionResult<ResourceModel>> GetResourceModel(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
                return BadRequest(new ArgumentNullException(resourceId));

            var resourceModel = await _resourceDomain.GetResourceAsync(resourceId);
            return resourceModel;
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

        // POST: api/Resource
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> AddResourceAsync(ResourceModel resource)
        {
            if (resource == null)
                return BadRequest(new ArgumentNullException());

            return await _resourceDomain.AddResourceAsync(resource);
        }

        // DELETE: api/Resource/5
        [HttpDelete("{resourceId}")]
        public async Task<IActionResult> DeleteResource(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
                return BadRequest(new ArgumentNullException(resourceId));

            await _resourceDomain.DeleteResourceAsync(resourceId);
            return NoContent();
        }
    }
}
