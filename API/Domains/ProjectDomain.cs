using Microsoft.AspNetCore.Components;
using API.Services;

namespace API.Domains
{
    public class ProjectDomain
    {
        [Inject] private TimesheetDataService _tds { get; set; }

        public ProjectDomain()
        {

        }

        public async Task<bool> GetSomething()
        {
            await _tds.GetAllProjects();
            return true;
        }

    }
}
