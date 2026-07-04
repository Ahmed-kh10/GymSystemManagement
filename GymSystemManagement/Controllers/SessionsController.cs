using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SessionsController : Controller
{
    private readonly ISessionService _service;
    private readonly IUnitOfWork _unit;

    public SessionsController(ISessionService service, IUnitOfWork unit)
    {
        _service = service;
        _unit = unit;
    }

    public async Task<IActionResult> Index()
    {
        var sessions = await _service.GetAllAsync();
        return View(sessions);
    }

    public async Task<IActionResult> Create()
    {
        await LoadDropdowns();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SessionCreateVM vm)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns();
            return View(vm);
        }

        await _service.CreateAsync(vm);

        TempData["SuccessMessage"] = "Session Created Successfully";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var session = await _service.GetByIdAsync(id);

        if (session == null)
            return NotFound();

        return View(session);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var session = await _unit.Sessions.GetByIdAsync(id);

        if (session == null)
            return NotFound();

        await LoadDropdowns();

        var vm = new SessionEditVM
        {
            Id = session.Id,
            TrainerId = session.TrainerId,
            Description = session.Description,
            StartDate = session.StartDate,
            EndDate = session.EndDate
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, SessionEditVM vm)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns();
            return View(vm);
        }

        await _service.UpdateAsync(id, vm);

        TempData["SuccessMessage"] = "Session Updated Successfully";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var session = await _service.GetByIdAsync(id);

        if (session == null)
            return NotFound();

        return View(session);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);

        TempData["SuccessMessage"] = "Session Deleted Successfully";
        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDropdowns()
    {
        var trainers = await _unit.Trainers.GetAllAsync();
        var categories = await _unit.Categories.GetAllAsync();

        ViewBag.Trainers = new SelectList(trainers, "Id", "Name");
        ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
    }
}