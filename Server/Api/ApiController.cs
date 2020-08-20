using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.Api
{
    [ApiController]
    [Route("/api")]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("echo")]
        public List<string> echo()
        {
            return new List<string>(){"1", "2"};
        }
    }
}