using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
    private readonly IJobService _jobService;
    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    // [HttpPost]
    public IActionResult GetJobByID(int id)
    {
        return View();
    }
}