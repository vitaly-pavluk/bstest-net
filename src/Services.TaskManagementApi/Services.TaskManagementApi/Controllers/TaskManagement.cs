using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Services.TaskManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagement : ControllerBase
    {
        private static readonly List<WorkTask> _workTasks =new();

        private readonly ILogger<TaskManagement> _logger;

        public TaskManagement(ILogger<TaskManagement> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WorkTask> Get()
        {
            return _workTasks;
        }

        [HttpPost]
        public void Post([Required(AllowEmptyStrings = false)]string summary)
        {
            _workTasks.Add(new WorkTask{CreatedAt = DateTime.UtcNow,Summary = summary});
        }
    }
}