using System.Net;
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
        [ProducesResponseType(typeof(WorkTaskInfo[]),StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {

            try
            {
                var tasks = await _storageService.GetWorkTasks();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Failed to get tasks from backend controller");
                return BadRequest( new {Error = e.ToString()});
            }
        }
    }
}