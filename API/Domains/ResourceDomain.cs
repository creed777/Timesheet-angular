using API.Interfaces;
using API.Models;

namespace API.Domains
{
    public class ResourceDomain : IResourceDomain
    {
        private IResourceDataService _tds { get; set; }

        public ResourceDomain(IResourceDataService tds)
        {
            _tds = tds;
        }

        public async Task<List<ResourceModel>> GetAllResourcesAsync()
        {
            return await _tds.GetAllResourcesAsync();
        }

        public async Task<ResourceModel> GetResourceByIdAsync(string resourceId)
        {
            if (resourceId == null)
                return new ResourceModel();

            return await _tds.GetResourceByIdAsync(resourceId);
        }

        public async Task<int> AddResourceAsync(ResourceModel resource)
        {
            if (resource == null)
                return -1;

            return await _tds.AddResourceAsync(resource);
        }

        public async Task<int> DeleteResourceAsync(string resourceId)
        {
            if (resourceId == null)
                return -1;

            return await _tds.DeleteResourceAsync(resourceId);
        }
    }
}
