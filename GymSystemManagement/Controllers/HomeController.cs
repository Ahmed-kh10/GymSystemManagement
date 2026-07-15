using GymSystemManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;


namespace GymSystemManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberService _memberService;
        private readonly ITrainerService _trainerService;
        private readonly ISessionService _sessionService;

        public HomeController(
            ILogger<HomeController> logger,
            IMemberService memberService,
            ITrainerService trainerService,
            ISessionService sessionService)
        {
            _logger = logger;
            _memberService = memberService;
            _trainerService = trainerService;
            _sessionService = sessionService;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllAsync();
            var trainers = await _trainerService.GetAllAsync();

            ViewBag.TotalMembers = members.Count;

            ViewBag.ActiveMembers = members.Count; 

            ViewBag.TotalTrainers = trainers.Count;

            ViewBag.UpcomingSessions =
                await _sessionService.GetUpcomingCountAsync();

            ViewBag.OngoingSessions =
                await _sessionService.GetOngoingCountAsync();

            ViewBag.CompletedSessions =
                await _sessionService.GetCompletedCountAsync();

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
