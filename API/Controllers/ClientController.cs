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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ClientController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ClientModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetAllClients()
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            return await _context.Client.ToListAsync();
        }

        // GET: api/ClientModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClient(int id)
        {
          if (_context.Client == null)
          {
              return NotFound();
          }
            var clientModel = await _context.Client.FindAsync(id);

            if (clientModel == null)
            {
                return NotFound();
            }

            return clientModel;
        }

        // PUT: api/ClientModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(int id, ClientModel clientModel)
        //{
        //    if (id != clientModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(clientModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientModelExists(id))
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

        // POST: api/PostClient
        // To protect from ove4rposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{ClientModel}")]
        public async Task<ActionResult<ClientModel>> AddClient(ClientModel clientModel)
        {
          if (_context.Client == null)
          {
              return Problem("Entity set 'DatabaseContext.Client'  is null.");
          }

            _context.Client.Add(clientModel);
            var result = await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientModel", new { id = clientModel.Id }, clientModel);
        }

        // POST: api/PostClient
        // To protect from ove4rposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{ClientModel}")]
        public async Task<ActionResult<ClientModel>> UpdateClient(ClientModel clientModel)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'DatabaseContext.Client'  is null.");
            }

            _context.Client.Attach(clientModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ClientModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Client == null)
            {
                return NotFound();
            }
            var clientModel = await _context.Client.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }

            _context.Client.Remove(clientModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ClientModelExists(int id)
        {
            return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
