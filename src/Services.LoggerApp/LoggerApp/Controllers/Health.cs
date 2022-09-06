using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggerApp.Controllers
{
    [Route("/health")]
    [ApiController]
    public class Health : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "All OK";
        }
    }
}
