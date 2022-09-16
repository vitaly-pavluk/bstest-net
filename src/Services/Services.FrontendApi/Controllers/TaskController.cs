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
        private readonly WorkTaskBackendService _backendService;

        public TasksController(ILogger<TasksController> logger, WorkTaskBackendService backendService)
        {
            _logger = logger;
            _backendService = backendService;
        }
        /// <summary>
        /// Returns data from the in-memory collection
        /// </summary>
        /// <returns></returns>
        [HttpGet("local", Name = "GetLocalTasks")]
        public IEnumerable<WorkTask> GetLocalTasks()
        {
            using (_logger.BeginScope("Get all tasks"))
            {
                return Enumerable.Range(0, 10)
                    .Select(i => new WorkTask
                    {
                        WorkTaskId = $"{i:D}",
                        Summary = "Lorem ipsum " + i.ToString().PadLeft(5, '0')
                    }).ToArray();
            }
        }

        /// <summary>
        /// Returns tasks from the Backend Service by calling it via HTTPClient
        /// </summary>
        /// <returns></returns>
        [HttpGet("remote", Name = "GetRemoteTasks")]
        public async Task<IEnumerable<WorkTask>> GetRemoteTasks()
        {
            return await _backendService.GetAllTasks();
        }
    }
}