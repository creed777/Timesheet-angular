using API.Interfaces;
using API.DTO;
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
        /// <returns><see cref="IEnumerable{ClientDto}"/></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAllClients()
        {
            var result = await _clientDomain.GetAllClientsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Returns a client by client Id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns><see cref="ActionResult{ClientDto}"/></returns>
        [HttpGet("{clientId}")]
        public async Task<ActionResult<ClientDto>> GetClient(int clientId)
        {
            if (clientId == 0)
                return BadRequest(new ArgumentNullException(clientId.ToString()));

            return Ok(await _clientDomain.GetClientByIdAsync(clientId));
        }

        /// <summary>
        /// Adds a new client
        /// </summary>
        /// <param name="client"></param>
        /// <returns><see cref="ActionResult{ClientDto}"/></returns>
        [HttpPost()]
        public async Task<ActionResult<ClientDto>> AddClient(CreateClientDto client)
        {
            var result = await _clientDomain.AddClientAsync(client);

            if (client == null)
                BadRequest(new ArgumentNullException());

            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("There was a problem adding the client");
            }
        }

        /// <summary>
        /// Hard deletes a client record by Id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns><see cref="ActionResult"/></returns>
        
        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(string clientId)
        {
            if(string.IsNullOrEmpty(clientId))
                return BadRequest(new ArgumentNullException(clientId));

            var result =  await _clientDomain.DeleteClient(clientId);
            return Ok("Client record deleted.");
        }

        /// <summary>
        /// Get a list of Client Status
        /// </summary>
        /// <returns><see cref="ActionResult{ClientStatusDto}"/></returns>
        [HttpGet]
        public async Task<IActionResult> GetClientStatusListAsync()
        {
            return Ok(await _clientDomain.GetClientStatusListAsync()) ;
        }
    }
}
