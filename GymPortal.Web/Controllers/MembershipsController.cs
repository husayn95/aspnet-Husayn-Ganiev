using GymPortal.Domain.Entities;
using GymPortal.Domain.Enums;
using GymPortal.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymPortal.Web.Controllers;

public class MembershipsController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public MembershipsController(AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

public async Task<IActionResult> Index()
{
    Membership? membership = null;

    if (User.Identity?.IsAuthenticated ?? false)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null)
        {
            membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.UserId == user.Id);
        }
    }

    return View(membership);
}
    [HttpPost]
    public async Task<IActionResult> Create(MembershipType type)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
            return RedirectToAction("Login", "Account");

        var exists = await _context.Memberships
            .AnyAsync(m => m.UserId == user.Id);

        if (exists)
        {
            TempData["Error"] = "You already have a membership.";
            return RedirectToAction("Index");
        }

        var membership = new Membership
        {
            UserId = user.Id,
            Type = type,
            StartDate = DateTime.UtcNow,
            IsActive = true
        };

        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Membership created!";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Toggle()
    {
        var user = await _userManager.GetUserAsync(User);

        var membership = await _context.Memberships
            .FirstOrDefaultAsync(m => m.UserId == user!.Id);

        if (membership == null)
        {
            TempData["Error"] = "No membership found.";
            return RedirectToAction("Index");
        }

        membership.IsActive = !membership.IsActive;

        await _context.SaveChangesAsync();

        TempData["Success"] = "Membership updated.";
        return RedirectToAction("Index");
    }
}