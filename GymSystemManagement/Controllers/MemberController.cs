using Microsoft.AspNetCore.Mvc;

public class MembersController : Controller
{
    private readonly IMemberService _service;

    public MembersController(IMemberService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var members = await _service.GetAllAsync();
        return View(members);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MemberCreateVM vm)
    {
        try
        {
            Console.WriteLine("ENTER CREATE POST");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("MODEL INVALID");

                foreach (var item in ModelState)
                {
                    foreach (var error in item.Value.Errors)
                    {
                        Console.WriteLine(item.Key + " => " + error.ErrorMessage);
                    }
                }

                return View(vm);
            }

            Console.WriteLine("BEFORE SAVE");

            await _service.CreateAsync(vm);

            Console.WriteLine("AFTER SAVE");

            TempData["Success"] = "Created Successfully";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        var vm = new MemberEditVM
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Phone = member.Phone,
            DateOfBirth = member.DateOfBirth,
            Gender = member.Gender,
            City = member.Address.City,
            Street = member.Address.street,
            BuildingNumber = member.Address.Building,
            Height = member.Healthrecord?.Height ?? 0,
            Weight = member.Healthrecord?.weight ?? 0,
            BloodType = member.Healthrecord?.BloodType,
            Note = member.Healthrecord?.Note
        };

        return View(vm);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(MemberEditVM vm, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _service.UpdateAsync(vm.Id, vm);

        TempData["Success"] = "Updated Successfully";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        return View(member);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);

        TempData["Success"] = "Deleted Successfully";
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> MemberDetails(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        var vm = new MemberDetailsVM
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Phone = member.Phone,
            Gender = member.Gender.ToString(),
            DateOfBirth = member.DateOfBirth.ToString("dd MMM yyyy"),
            Address = $"{member.Address.Building}, {member.Address.street}, {member.Address.City}",
            Photo = member.Photo,
            PlanName = member.MemberShips?
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefault()?.Plan?.Name,
            MembershipStartDate = member.MemberShips?
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefault()?.CreatedAt.ToString("dd MMM yyyy"),
            MembershipEndDate = member.MemberShips?
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefault()?.EndDate.ToString("dd MMM yyyy")
        };

        return View(vm);
    }

    public async Task<IActionResult> HealthRecordDetails(int id)
    {
        var member = await _service.GetByIdAsync(id);

        if (member == null)
            return NotFound();

        if (member.Healthrecord == null)
            return Content("No Health Record");

        return View(member.Healthrecord);
    }
}