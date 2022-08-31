using Microsoft.AspNetCore.Mvc;
using Services.WebApp01.Models;

namespace Services.WebApp01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WorkTask> Get()
        {
            return Storage.Tasks;
        }

        [HttpPost(Name = "CreateTask")]
        public void Post(WorkTask task)
        {
            Storage.Tasks.Add(task);
        }
    }
}