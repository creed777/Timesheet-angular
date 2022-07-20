using API.DTO;

namespace API.Interfaces
{
    public interface IResourceDomain
    {
        Task<List<ResourceDto>> GetResourcesByTypeAsync(int resourceTypeName);
        Task<List<ResourceTypeDto>> GetResourceTypeList();
        Task<ResourceDto> GetResourceByIdAsync(int resourceId);
        Task<int> AddResourceAsync(CreateResourceDto resource);
        Task<int> DeleteResourceAsync(int resourceId);
    }
}
