using API.Interfaces;
using API.Models;
using API.DTO;

namespace API.Domains
{
    public class ResourceDomain : IResourceDomain
    {
        private IResourceDataService _tds { get; set; }

        public ResourceDomain(IResourceDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<ResourceDto>> GetResourcesByTypeAsync(string resourceTypeName)
        {
            if (resourceTypeName == null)
                return null;

            var result = await _tds.GetResourcesByTypeAsync(resourceTypeName);
            List<ResourceDto> mapping = result.ConvertAll<ResourceDto>(x => x);
            return mapping;
        }

        public async Task<List<ResourceTypeDto>> GetResourceTypeList()
        {
            var result = await _tds.GetResourceTypeList();
            List<ResourceTypeDto> mapping = result.ConvertAll<ResourceTypeDto>(x => x);
            return mapping;
        }

        public async Task<ResourceDto> GetResourceByIdAsync(int resourceId)
        {
            if (resourceId == 0)
                return new ResourceModel();

            return await _tds.GetResourceByIdAsync(resourceId);
        }

        public async Task<int> AddResourceAsync(ResourceDto resource)
        {
            if (resource == null)
                return -1;

            ResourceModel mapping = resource;
            return  await _tds.AddResourceAsync(mapping);
        }

        public async Task<int> DeleteResourceAsync(int resourceId)
        {
            if (resourceId == 0)
                return -1;

            return await _tds.DeleteResourceAsync(resourceId);
        }
    }
}
