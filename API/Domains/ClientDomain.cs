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

        public async Task<ClientDto> GetClientByIdAsync(int clientId)
        {
            var result = await _tds.GetClientByIdAsync(clientId);

            if(result.ClientId == 0)
            {
                return null;
            }
            var dtoMapped = result;
            return dtoMapped;
        }

        public async Task<List<ClientDto>> GetAllClientsAsync()
        {
            var result = await _tds.GetAllClientsAsync();

            List<ClientDto> dtoMapped = result.ConvertAll<ClientDto>(x => x);
            return dtoMapped;
        }

        public async Task<int> AddClientAsync(CreateClientDto client)
        {
            ClientModel clientModel = client;

            return await _tds.AddClientAsync(clientModel);
        }

        public async Task<int> DeleteClient(string clientId)
        {
            return await _tds.DeleteClient(clientId);
        }

        public async Task<List<ClientStatusDto>> GetClientStatusListAsync()
        {
            var clientStatusModel = await _tds.GetClientStatusListAsync();
            List<ClientStatusDto> clientStatusDto = clientStatusModel.ConvertAll<ClientStatusDto>(x => x);
            return clientStatusDto;
        }
    }
}
