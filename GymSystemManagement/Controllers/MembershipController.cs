using GymSystemManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class MembershipController : Controller
{
    private readonly IMembershipService _membershipService;
    private readonly IMemberService _memberService;
    private readonly IPlanService _planService;

    public MembershipController(
        IMembershipService membershipService,
        IMemberService memberService,
        IPlanService planService)
    {
        _membershipService = membershipService;
        _memberService = memberService;
        _planService = planService;
    }

    public async Task<IActionResult> Index()
    {
        var memberships = await _membershipService.GetAllAsync();
        return View(memberships);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Members = new SelectList(
            await _memberService.GetAllAsync(),
            "Id",
            "Name");

        ViewBag.Plans = new SelectList(
            await _planService.GetAllAsync(),
            "Id",
            "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMembershipVM vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Members = new SelectList(
                await _memberService.GetAllAsync(),
                "Id",
                "Name");

            ViewBag.Plans = new SelectList(
                await _planService.GetAllAsync(),
                "Id",
                "Name");

            return View(vm);
        }

        try
        {
            await _membershipService.CreateAsync(vm);

            TempData["SuccessMessage"] = "Membership Created Successfully";

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;

            ViewBag.Members = new SelectList(
                await _memberService.GetAllAsync(),
                "Id",
                "Name");

            ViewBag.Plans = new SelectList(
                await _planService.GetAllAsync(),
                "Id",
                "Name");

            return View(vm);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cancel(int id)
    {
        try
        {
            await _membershipService.CancelAsync(id);

            TempData["SuccessMessage"] = "Membership Cancelled Successfully";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}