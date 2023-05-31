using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace Recruiting.API.Controllers
{
    //Attribute routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //http:localhost/api/job
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            
            //return Json Data, and HTTP status codes
            //serialization c# objects into json Objects using System,Text.Json
            if (!jobs.Any())
            {
                //no job exist, 404
                return NotFound(new {error="No Jobs Found"});
            }

            return Ok(jobs);
        }

        //http:localhost/api/job/4
        [HttpGet]
        [Route("{id:int}", Name = "GetJobDetails")] //this 'id' should be then same name as param 'id'
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { errorMessage = "No job found for this id" });
            }

            return Ok(job);
        }
        
        //http:localhost/api/job
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateJob(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); //400 status code
            }
            var job = await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new { Controller = "job", id = job }, "Created success");
        }
        
        //http:localhost/api/job/update
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateJob(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); //400 status code
            }
            var job = await _jobService.UpdateJob(model);
            return CreatedAtAction("GetJobDetails", new { Controller = "job", id = job }, "Updated success");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobService.DeleteJob(id);
            // return CreatedAtAction("GetJobDetails", new { Controller = "job", id = job }, "Delete success");
            return Ok("Delete success");
        }
    }
}
