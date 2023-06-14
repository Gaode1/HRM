using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSubmissons()
        {
            var submission = await _submissionService.GetAllAsync();
            if (!submission.Any())
            {
                return NotFound("No submissions found.");
            }
            return Ok(submission);
        }

        [HttpGet]
        [Route("job/{id:int}")]
        public async Task<IActionResult> GetSubmissionByJobId(int id)
        {
            var submissions = await _submissionService.GetSubmissionsByJobId(id);
            if (!submissions.Any())
            {
                return NotFound("No submissions found.");
            }
            return Ok(submissions);
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSubmissionById(int id)
        {
            var submissions = await _submissionService.GetByIdAsync(id);
            if (submissions == null)
            {
                return NotFound("No submissions found");
            }
            return Ok(submissions);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSubmission(SubmissionRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var submission = await _submissionService.AddTAsync(new Submission()
            {
                Id = requestModel.Id, CandidateId = requestModel.CandidateId, JobId = requestModel.JobId,
                RejectedOn = requestModel.RejectedOn, RejectReason = requestModel.RejectReason,
                ApprovedForInterview = requestModel.ApprovedForInterview, SubmittedOn = DateTime.UtcNow
            });
            return CreatedAtAction("GetSubmissionById", new { Controller = "submission", id = submission.Id },"Created success");
            // return Ok(submission);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateSubmission(SubmissionRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var submission = await _submissionService.UpdateTAsync(new Submission()
            {
                Id = requestModel.Id, CandidateId = requestModel.CandidateId, JobId = requestModel.JobId,
                RejectedOn = requestModel.RejectedOn, RejectReason = requestModel.RejectReason,
                ApprovedForInterview = requestModel.ApprovedForInterview, SubmittedOn = DateTime.UtcNow
            });
            return CreatedAtAction("GetSubmissionById", new { Controller = "submission", id = submission.Id },"Update success");
            // return Ok(submission);
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSubmission(int id)
        {
            var submission= await _submissionService.DeleteAsync(id);
            return Ok("Deleted");
        }
    }
}
