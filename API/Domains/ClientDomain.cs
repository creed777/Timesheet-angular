using API.Interfaces;
using API.Models;
using API.DTO;

namespace API.Domains
{
    public class ClientDomain : IClientDomain
    {
        private IClientDataServices _tds { get; set; }

        public ClientDomain(IClientDataServices tds)
        {
            _tds = tds;
        }

        public async Task<ClientDto> GetClientAsync(string clientId)
        {
            var result = await _tds.GetClientAsync(clientId);

            var dtoMapped = result;
            return dtoMapped;
        }

        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            var result = await _tds.GetAllClientsAsync();

            List<ClientDto> dtoMapped = result.ConvertAll<ClientDto>(x => x);
            return dtoMapped;
        }

        public async Task<int> AddClientAsync(ClientDto client)
        {
            ClientModel clientModel = client;

            return await _tds.AddClientAsync(clientModel);
        }

        public async Task<int> DeleteClient(string clientId)
        {
            return await _tds.DeleteClient(clientId);
        }

        public async Task<List<ClientStatusModel>> GetClientStatusListAsync()
        {
            return await _tds.GetClientStatusListAsync();
        }
    }
}
