using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb1.Controllers;

public class SubmissionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}