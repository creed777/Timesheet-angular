using API.Models;

namespace API.Interfaces
{
    public interface IResourceDataService
    {
        Task<List<ResourceModel>> GetResourcesByTypeAsync(string resourceTypeName);
        Task<List<ResourceTypeModel>> GetResourceTypeList();
        Task<ResourceModel> GetResourceByIdAsync(int resourceId);
        Task<int> AddResourceAsync(ResourceModel resource);
        Task<int> DeleteResourceAsync(int resourceId);
    }
}
