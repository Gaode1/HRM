using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InterviewController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllInterviews()
        {
            var interviews = new List<string>(new[] { "qwe", "asd", "zxc" });
            return Ok(interviews);
        }
    }
}
