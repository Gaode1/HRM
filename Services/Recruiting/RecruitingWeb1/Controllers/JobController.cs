using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb1.Controllers;

public class JobController : Controller
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    public IActionResult Index()
    {
        List<JobResponseModel> jobs =_jobService.GetAllJobs();
        return View(jobs);
    }
}