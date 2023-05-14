using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb1.Controllers;

public class CandidateController : Controller
{
    private readonly ICandidateService _candidateService;
    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Candidates()
    {
        List<CandidateResponseModel> candidates = _candidateService.GetAllCandidates();
        return View(candidates);
    }
}