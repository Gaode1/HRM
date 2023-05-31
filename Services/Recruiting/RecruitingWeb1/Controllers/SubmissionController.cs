using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb1.Controllers;

public class SubmissionController : Controller
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }
    // GET
    public async Task<ViewResult> Index()
    {
        IEnumerable<Submission> submission = await _submissionService.GetAllAsync();
        return View(submission);
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }
}