using Microsoft.AspNetCore.Mvc;
using PP.API.EC;
using PP.Library.DTO;

namespace PP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public ProjectDTO? AddOrUpdate([FromBody] ProjectDTO project)
        {
            return new ProjectEC().AddOrUpdate(project);
        }

        [HttpGet]
        public IEnumerable<ProjectDTO> GetAll()
        {
            return new ProjectEC().GetAll();
        }
    }
}
