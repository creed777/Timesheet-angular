﻿using API.Models;

namespace API.Interfaces
{
    public interface IResourceDataService
    {
        Task<ResourceModel> GetResourceAsync(string resourceId);
        Task<List<ResourceModel>> GetAllResourcesAsync();
        Task<int> AddResourceAsync(ResourceModel resource);
        Task<int> DeleteResourceAsync(string resourceId);
    }
}