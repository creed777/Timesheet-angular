using API.DTO;

namespace API.Interfaces
{
    public interface IClientDomain
    {
        Task<ClientDto> GetClientByIdAsync(string clientId);
        Task<List<ClientDto>> GetAllClientsAsync();
        Task<int> AddClientAsync(ClientDto client);
        Task<int> DeleteClient(string clientId);
        Task<List<ClientStatusDto>> GetClientStatusListAsync();
    }
}
