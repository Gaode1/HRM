using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
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

    [HttpPost]
    public IActionResult Detail(int id)
    {
        JobResponseModel job = _jobService.GetJobById(id);
        return View(job);
    }

    public IActionResult Create()
    {
        return View();
    }
}