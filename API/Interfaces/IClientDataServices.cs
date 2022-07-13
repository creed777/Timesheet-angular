using API.Models;

namespace API.Interfaces
{
    public interface IClientDataServices
    {
        Task<ClientModel> GetClientByIdAsync(string clientId);
        Task<List<ClientModel>> GetAllClientsAsync();
        Task<int> AddClientAsync(ClientModel client);
        Task<int> DeleteClient(string clientId);
        Task<List<ClientStatusModel>> GetClientStatusListAsync();
    }
}
