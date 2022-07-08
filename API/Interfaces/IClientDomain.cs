using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface IClientDomain
    {
        Task<ClientDto> GetClientAsync(string clientId);
        Task<List<ClientDto>> GetAllClientsAsync();
        Task<int> AddClientAsync(ClientDto client);
        Task<int> DeleteClient(string clientId);
        Task<List<ClientStatusModel>> GetClientStatusListAsync();
    }
}
