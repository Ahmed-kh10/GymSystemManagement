using GymSystemmanagement.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize]

public class TrainersController : Controller
{
    private readonly ITrainerService _service;

    public TrainersController(ITrainerService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var trainers = await _service.GetAllAsync();

        return View("~/Views/Trainers/Index.cshtml", trainers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(TrainerCreateVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _service.CreateAsync(vm);
        TempData["Success"] = "Trainer Added Successfully";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var trainer = await _service.GetByIdAsync(id);
        if (trainer == null) return NotFound();

        var vm = new TrainerDetailsVM
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Email = trainer.Email,
            Phone = trainer.Phone,
            DateOfBirth = trainer.DateOfBirth.ToString("dd MMM yyyy"),
            Address = $"{trainer.Address.Building} - {trainer.Address.street} - {trainer.Address.City}",
            Specialty = trainer.Specialty.ToString()
        };

        return View(vm);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var trainer = await _service.GetByIdAsync(id);
        if (trainer == null) return NotFound();

        var vm = new TrainerEditVM
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Email = trainer.Email,
            Phone = trainer.Phone,
            City = trainer.Address.City,
            Street = trainer.Address.street,
            BuildingNumber = trainer.Address.Building,
            Specialty = trainer.Specialty
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TrainerEditVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _service.UpdateAsync(id, vm);
        TempData["Success"] = "Trainer Updated Successfully";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var trainer = await _service.GetByIdAsync(id);
        if (trainer == null) return NotFound();
        return View(trainer);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        TempData["Success"] = "Trainer Deleted Successfully";
        return RedirectToAction(nameof(Index));
    }
}