using API.Interfaces;
using API.Models;

namespace API.Domains
{
    public class ClientDomain : IClientDomain
    {
        private IClientDataServices _tds { get; set; }

        public ClientDomain(IClientDataServices tds)
        {
            _tds = tds;
        }

        public async Task<List<ClientModel>> GetClientAsync(string clientId)
        {

            var result = await _tds.GetClientAsync(clientId);
            return result;
        }

        public async Task<List<ClientModel>> GetAllClientsAsync()
        {
            return await _tds.GetAllClientsAsync();
        }

        public async Task<int> AddClientAsync(ClientModel client)
        {
            return await _tds.AddClientAsync(client);
        }

        public async Task<int> DeleteClient(string clientId)
        {
            return await _tds.DeleteClient(clientId);
        }

    }
}
