using API.DTO;

namespace API.Interfaces
{
    public interface IResourceDomain
    {
        Task<List<ResourceDto>> GetResourcesByTypeAsync(string resourceTypeName);
        Task<List<ResourceTypeDto>> GetResourceTypeList();
        Task<ResourceDto> GetResourceByIdAsync(string resourceId);
        Task<int> AddResourceAsync(ResourceDto resource);
        Task<int> DeleteResourceAsync(string resourceId);
    }
}
