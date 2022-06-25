using Microsoft.AspNetCore.Mvc;
using Timesheet_angular.Models;
using Timesheet_angular.Services;

namespace Timesheet_angular.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly DatabaseContext _databaseContext;

        public ProjectController(ILogger<ProjectController> logger, DatabaseContext db)
        {
            _logger = logger;
            _databaseContext = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectModel>> Get()
        {
            var result = _databaseContext.Project.Where(x => x.ActualTotalHours == 0).ToList();
            return Ok(result);
        }
    }
}
