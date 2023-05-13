using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
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