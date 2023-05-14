using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb1.Controllers;

public class StatusController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}