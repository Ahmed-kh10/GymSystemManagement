using GymSystemManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymSystemManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberService _memberService;

        public HomeController(ILogger<HomeController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllAsync();
            ViewBag.TotalMembers = members.Count;
            ViewBag.ActiveMembers = 0;
            ViewBag.TotalTrainers = 0;
            ViewBag.UpcomingSessions = 0;
            ViewBag.OngoingSessions = 0;
            ViewBag.CompletedSessions = 0;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
