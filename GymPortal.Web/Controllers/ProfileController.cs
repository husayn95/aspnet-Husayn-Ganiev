using GymPortal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymPortal.Infrastructure.Data;

namespace GymPortal.Web.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AppDbContext _context;

    public ProfileController(
        UserManager<ApplicationUser> userManager,
        AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var fullUser = await _context.Users
            .Include(x => x.Membership)
            .Include(x => x.Bookings)
                .ThenInclude(b => b.GymClass)
            .FirstOrDefaultAsync(x => x.Id == user.Id);

        return View(fullUser);
    }
}