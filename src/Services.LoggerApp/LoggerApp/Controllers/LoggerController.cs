using System.ComponentModel.DataAnnotations;
using LoggerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoggerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private static readonly List<string> Log = new();

        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllLogs")]
        public IEnumerable<LogEntry> Get()
        {
            return Log.Select(le=>new LogEntry
            {
                Log= le

            }).ToArray();
        }

        [HttpPost]
        public void Post([Required(AllowEmptyStrings = false)]string logEntry)
        {
            Log.Add(logEntry);
        }
    }
}