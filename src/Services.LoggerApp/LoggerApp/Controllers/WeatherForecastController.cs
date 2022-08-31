using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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
                Log= le,Hash=le.ToMd5HashString()

            }).ToArray();
        }

        [HttpPost]
        public void Post([Required(AllowEmptyStrings = false)]string logEntry)
        {
            Log.Add(logEntry);
        }
    }

    public class LogEntry
    {
        public string Log { get; set; }
        public string Hash { get; set; }
    }
}