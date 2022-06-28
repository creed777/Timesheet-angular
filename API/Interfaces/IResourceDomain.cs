using API.Models;

namespace API.Interfaces
{
    public interface IResourceDomain
    {
        Task<List<ResourceModel>> GetAllResourcesAsync();
        Task<ResourceModel> GetResourceAsync(string resourceId);
        Task<int> AddResourceAsync(ResourceModel resource);
        Task<int> DeleteResourceAsync(string resourceId);
    }
}
