using GymSystemmanagement.DAL.Models;
using GymSystemManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymSystemManagement.PL.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _service;

        public PlanController(IPlanService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var plans = await _service.GetAllAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id)
        {
            var plan = await _service.GetByIdAsync(id);
            if (plan == null) return NotFound();
            return View(plan);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var plan = await _service.GetByIdAsync(id);
            if (plan == null) return NotFound();

            var vm = new PlanEditVM
            {
                Id = plan.Id,
                PlanName = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlanEditVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var plan = await _service.GetByIdAsync(id);
            if (plan == null) return NotFound();

            plan.Name = vm.PlanName;
            plan.Description = vm.Description;
            plan.DurationDays = vm.DurationDays;
            plan.Price = vm.Price;

            await _service.UpdateAsync(plan);
            TempData["Success"] = "Plan Updated Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleActivation(int id)
        {
            var plan = await _service.GetByIdAsync(id);
            if (plan == null) return NotFound();

            plan.IsActive = !plan.IsActive;
            await _service.UpdateAsync(plan);

            TempData["Success"] = plan.IsActive ? "Plan Activated" : "Plan Deactivated";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanEditVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var plan = new Plan
            {
                Name = vm.PlanName,
                Description = vm.Description,
                DurationDays = vm.DurationDays,
                Price = vm.Price,
                IsActive = true
            };

            await _service.AddAsync(plan);
            TempData["Success"] = "Plan Created Successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}