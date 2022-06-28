using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientDomain _clientDomain;

        public ClientController(IClientDomain clientDomain)
        {
            _clientDomain = clientDomain;
        }

        /// <summary>
        /// Returns a list of Clients
        /// </summary>
        /// <returns><see cref="IEnumerable{ClientModel}"/></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetAllClients()
        {
            var result = await _clientDomain.GetAllClientsAsync();
            return result;
        }

        /// <summary>
        /// Returns a client by client Id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns><see cref="ActionResult{ClientModel}"/></returns>
        [HttpGet("{clientId}")]
        public async Task<ActionResult<ClientModel>> GetClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                return BadRequest();

            return Ok(await _clientDomain.GetClientAsync(clientId));
        }

        /// <summary>
        /// Adds a new client
        /// </summary>
        /// <param name="clientModel"></param>
        /// <returns><see cref="ActionResult{ClientModel}"/></returns>
        [HttpPost("{clientModel}")]
        public async Task<ActionResult<ClientModel>> AddClient(ClientModel clientModel)
        {
            return Ok(await _clientDomain.AddClientAsync(clientModel));
        }

        /// <summary>
        /// Updates an existing client record
        /// </summary>
        /// <param name="clientModel"></param>
        /// <returns><see cref="ActionResult{ClientModel}"/></returns>
        //[HttpPost("{ClientModel}")]
        //public async Task<ActionResult<ClientModel>> UpdateClient(ClientModel clientModel)
        //{
        //    if (clientModel == null)
        //        return BadRequest();

        //    _clientDomain.Upd(clientModel);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        /// <summary>
        /// Permanently deletes a client record by Id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            if(string.IsNullOrEmpty(clientId))
                return BadRequest();

            return Ok( await _clientDomain.DeleteClient(clientId));
        }
    }
}
