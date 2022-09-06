using Microsoft.AspNetCore.HeaderPropagation;
using Microsoft.AspNetCore.Mvc;
using Services.FrontendApi.Models;
using Services.FrontendApi.Services;

namespace Services.FrontendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly WorkTaskService _service;

        public TasksController(ILogger<TasksController> logger, WorkTaskService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("local", Name = "GetLocalTasks")]
        public IEnumerable<WorkTask> GetLocalTasks()
        {
            using (_logger.BeginScope("Get all tasks"))
            {
                return Enumerable.Range(0, 10)
                    .Select(i => new WorkTask
                    {
                        CreatedAt = DateTime.UtcNow,
                        Summary = "Lorem ipsum" + i.ToString().PadLeft(5, '0')
                    }).ToArray();
            }
        }

        [HttpGet("remote", Name = "GetRemoteTasks")]
        public async Task<IEnumerable<WorkTask>> GetRemoteTasks()
        {
            return await _service.GetAllTasks();
        }
    }
}