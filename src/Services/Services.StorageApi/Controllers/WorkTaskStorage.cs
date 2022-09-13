using Microsoft.AspNetCore.Mvc;

namespace Services.StorageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkTaskStorage : ControllerBase
    {

        private static List<WorkTask> _workTasksStorage = new();

        private readonly ILogger<WorkTaskStorage> _logger;

        public WorkTaskStorage(ILogger<WorkTaskStorage> logger)
        {
            _logger = logger;
        }

        [HttpGet("all",Name = "GetAll")]
        public IEnumerable<WorkTask> Get()
        {
            return _workTasksStorage;
        }

        [HttpPost("add")]
        public void CreateTask([FromBody]string? summary)
        {
            _workTasksStorage.Add(new WorkTask
            {
                WorkTaskId = DateTime.UtcNow.ToString("O"),
                Summary = (summary?? "New task") 
                          + 
                          "  kubernetes-route-as:" +
                          (
                              !Request.Headers.TryGetValue("kubernetes-route-as", out var k8srouteHeader)
                                  ?"#no k8s header in request#":k8srouteHeader
                          )
            });
        }
    }
}