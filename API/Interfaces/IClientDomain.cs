using API.DTO;

namespace API.Interfaces
{
    public interface IClientDomain
    {
        Task<ClientDto> GetClientByIdAsync(int clientId);
        Task<List<ClientDto>> GetAllClientsAsync();
        Task<int> AddClientAsync(CreateClientDto client);
        Task<int> DeleteClient(string clientId);
        Task<List<ClientStatusDto>> GetClientStatusListAsync();
    }
}
