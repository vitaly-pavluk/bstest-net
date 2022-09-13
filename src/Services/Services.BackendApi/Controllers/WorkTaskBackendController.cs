using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.BackendApi.Models;

namespace Services.BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkTaskBackendController : ControllerBase
    {
        private readonly ILogger<WorkTaskBackendController> _logger;
        private readonly WorkTaskStorageService _storageService;

        public WorkTaskBackendController
        (
            ILogger<WorkTaskBackendController> logger,
            WorkTaskStorageService storageService
        )
        {
            _logger = logger;
            _storageService = storageService;
        }

        [HttpGet("all", Name = "GetTasks")]
        [ProducesResponseType(typeof(WorkTaskInfo[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
           DumpRequest();
            try
            {
                var tasks = await _storageService.GetWorkTasks();

                _logger.LogInformation("Tasks: {tasks}",string.Join(";;\n\r",tasks.Select(t=>$"{t.WorkTaskId}:{t.Summary}")) );
                return Ok(tasks);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to get tasks from backend controller");
                return BadRequest(new { Error = e.ToString() });
            }
        }
        private void DumpRequest()
        {
            _logger.LogInformation
            (
                "Request {url} \n\r Headers: {headers}",
                Request.GetDisplayUrl(),
                string.Join(";;", Request.Headers.Select(h=>$"{h.Key}:{h.Value}"))
            );

        }
    }
}