using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    /// <summary>
    /// Endpoint to manage project resources
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Actions to manage resources
        /// </summary>
        /// <param name="context"></param>
        public ResourceController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Resource
        /// <summary>
        /// Returns all active project resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceModel>>> GetAllProjectResources()
        {
          if (_context.ProjectResources == null)
          {
              return NotFound();
          }
            return await _context.ProjectResources.ToListAsync();
        }

        // GET: api/Resource/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceModel>> GetResourceModel(int id)
        {
          if (_context.ProjectResources == null)
          {
              return NotFound();
          }
            var resourceModel = await _context.ProjectResources.FindAsync(id);

            if (resourceModel == null)
            {
                return NotFound();
            }

            return resourceModel;
        }

        // PUT: api/Resource/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResourceModel(int id, ResourceModel resourceModel)
        {
            if (id != resourceModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(resourceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Resource
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResourceModel>> PostResourceModel(ResourceModel resourceModel)
        {
          if (_context.ProjectResources == null)
          {
              return Problem("Entity set 'DatabaseContext.ProjectResources'  is null.");
          }
            _context.ProjectResources.Add(resourceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResourceModel", new { id = resourceModel.Id }, resourceModel);
        }

        // DELETE: api/Resource/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceModel(int id)
        {
            if (_context.ProjectResources == null)
            {
                return NotFound();
            }
            var resourceModel = await _context.ProjectResources.FindAsync(id);
            if (resourceModel == null)
            {
                return NotFound();
            }

            _context.ProjectResources.Remove(resourceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceModelExists(int id)
        {
            return (_context.ProjectResources?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
