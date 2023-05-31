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
    public async Task<ViewResult> Index()
    {
        List<JobResponseModel> jobs =await _jobService.GetAllJobs();
        return View(jobs);
    }

    // [HttpPost]
    public async Task<IActionResult> Detail(int id)
    {
        JobResponseModel job = await _jobService.GetJobById(id);
        return View(job);
    }

    [HttpGet]
    //show the empty page
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(JobRequestModel jobRequestModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        //save date into DB
        //then return to index view
        await _jobService.AddJob(jobRequestModel);
        return RedirectToAction("Index");
    }
}