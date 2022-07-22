using API.Interfaces;
using API.Models;
using API.DTO;

namespace API.Domains
{
    public class ResourceDomain : IResourceDomain
    {
        private bool IsGetRequest { get; set; }
        private IResourceDataService _tds { get; set; }

        public ResourceDomain(IResourceDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<ResourceDto>> GetResourcesByTypeAsync(int resourceTypeId)
        {
            if (resourceTypeId == 0)
                return null;

            var result = await _tds.GetResourcesByTypeAsync(resourceTypeId);
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

            var resourceModel = await _tds.GetResourceByIdAsync(resourceId);
            ResourceDto resourceDto = resourceModel;
            return resourceDto;
        }

        public async Task<int> AddResourceAsync(CreateResourceDto resource)
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
